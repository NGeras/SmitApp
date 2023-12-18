using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SmitApp.Core.Contracts.Services;
using SmitApp.Core.MovieDtos;

namespace SmitApp.BackendWorker;

public class Worker : BackgroundService
{
    private readonly ICategoryService _categoryService;
    private readonly ILogger<Worker> _logger;
    private readonly IMovieService _movieService;
    private IConnection _connection;
    private IModel _movieDetailsChannel;
    private IModel _moviesChannel;

    public Worker(ILogger<Worker> logger, ICategoryService categoryService, IMovieService movieService)
    {
        _logger = logger;
        _categoryService = categoryService;
        _movieService = movieService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();

            HandleMovieListRequests(_connection);

            HandleMovieDetailsRequests(_connection);

            while (!stoppingToken.IsCancellationRequested) await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
        catch (OperationCanceledException)
        {
            // When the stopping token is canceled, for example, a call made from services.msc,
            // we shouldn't exit with a non-zero exit code. In other words, this is expected...
            _connection.Dispose();
            _movieDetailsChannel.Dispose();
            _moviesChannel.Dispose();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Message}", ex.Message);

            // Terminates this process and returns an exit code to the operating system.
            // This is required to avoid the 'BackgroundServiceExceptionBehavior', which
            // performs one of two scenarios:
            // 1. When set to "Ignore": will do nothing at all, errors cause zombie services.
            // 2. When set to "StopHost": will cleanly stop the host, and log errors.
            //
            // In order for the Windows Service Management system to leverage configured
            // recovery options, we need to terminate the process with a non-zero exit code.
            Environment.Exit(1);
        }
    }

    private void HandleMovieListRequests(IConnection connection)
    {
        _moviesChannel = connection.CreateModel();
        _moviesChannel.QueueDeclare("movie_list_queue", false, false, false, null);

        var consumer = new EventingBasicConsumer(_moviesChannel);
        consumer.Received += (model, ea) =>
        {
            var movies = _movieService.GetMovies();
            var categories = _categoryService.GetCategories();
            var movieDtos = movies.Select(movie => new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                CategoryId = movie.CategoryId,
                CategoryName = categories.FirstOrDefault(cat => cat.Id == movie.CategoryId)?.Name,
                Rating = movie.Rating,
                Year = movie.Year
            });
            var replyProps = _moviesChannel.CreateBasicProperties();
            replyProps.CorrelationId = ea.BasicProperties.CorrelationId;

            var responseBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(movieDtos));
            _moviesChannel.BasicPublish("", ea.BasicProperties.ReplyTo, replyProps, responseBytes);
        };

        _moviesChannel.BasicConsume("movie_list_queue", true, consumer);
    }

    private void HandleMovieDetailsRequests(IConnection connection)
    {
        _movieDetailsChannel = connection.CreateModel();
        _movieDetailsChannel.QueueDeclare("movie_details_queue", false, false, false, null);

        var consumer = new EventingBasicConsumer(_movieDetailsChannel);
        consumer.Received += (model, ea) =>
        {
            var body = Encoding.UTF8.GetString(ea.Body.ToArray());
            var movieId = int.Parse(body);
            var movieDetail = _movieService.GetMovieDetailsById(movieId);
            var movieDetailDto = new MovieDetailDto
            {
                Id = movieDetail.Id,
                Title = movieDetail.Title,
                Description = movieDetail.Description,
                Rating = movieDetail.Rating,
                Year = movieDetail.Year
            };
            var replyProps = _movieDetailsChannel.CreateBasicProperties();
            replyProps.CorrelationId = ea.BasicProperties.CorrelationId;

            var responseBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(movieDetailDto));
            _movieDetailsChannel.BasicPublish("", ea.BasicProperties.ReplyTo, replyProps, responseBytes);
        };

        _movieDetailsChannel.BasicConsume("movie_details_queue", true, consumer);
    }
}