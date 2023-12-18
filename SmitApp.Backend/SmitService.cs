using System;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SmitApp.Backend.Movie;
using SmitApp.Core.Repositories;
using SmitApp.Core.Services;

namespace SmitApp.Backend
{
    public partial class SmitService : ServiceBase
    {
        private readonly CategoryService _categoryService;
        private readonly MovieService _movieService;
        private IConnection _connection;
        private IModel _movieDetailsChannel;
        private IModel _moviesChannel;

        public SmitService()
        {
            _movieService = new MovieService(new MovieRepository());
            _categoryService = new CategoryService(new CategoryRepository());
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672
            };

            _connection = factory.CreateConnection();

            HandleMovieListRequests(_connection);

            HandleMovieDetailsRequests(_connection);

            Console.WriteLine("Windows Service is running. Press [Enter] to exit.");
            Console.ReadLine();
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

        protected override void OnStop()
        {
            _connection.Dispose();
            _movieDetailsChannel.Dispose();
            _moviesChannel.Dispose();
        }
    }
}