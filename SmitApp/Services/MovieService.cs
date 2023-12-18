using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SmitApp.Contracts.Services;
using SmitApp.Models;
using System.Text;
using Newtonsoft.Json;

namespace SmitApp.Services;

public class MovieService : IMovieService
{
    private readonly IConnection _connection;

    public MovieService()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();

    }
    public async Task<IEnumerable<Movie>> GetMovies()
    {
        var channel = _connection.CreateModel();
        var replyQueueName = channel.QueueDeclare().QueueName;

        var props = channel.CreateBasicProperties();
        props.ReplyTo = replyQueueName;
        props.CorrelationId = Guid.NewGuid().ToString();

        var body = Encoding.UTF8.GetBytes("Request message");

        channel.BasicPublish(exchange: "", routingKey: "movie_list_queue", basicProperties: props, body: body);
        var tcs = new TaskCompletionSource<IEnumerable<Movie>>();
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            if (ea.BasicProperties.CorrelationId == props.CorrelationId)
            {
                var response = Encoding.UTF8.GetString(ea.Body.ToArray());
                var movies = JsonConvert.DeserializeObject<List<Movie>>(response);
                tcs.SetResult(movies);
            }
        };

        channel.BasicConsume(queue: replyQueueName, autoAck: true, consumer: consumer);
        return await tcs.Task;
    }

    public async Task<Movie> GetMovieDetails(int id)
    {
        var channel = _connection.CreateModel();
        var replyQueueName = channel.QueueDeclare().QueueName;

        var props = channel.CreateBasicProperties();
        props.ReplyTo = replyQueueName;
        props.CorrelationId = Guid.NewGuid().ToString();

        var body = Encoding.UTF8.GetBytes(id.ToString());

        channel.BasicPublish(exchange: "", routingKey: "movie_details_queue", basicProperties: props, body: body);
        var tcs = new TaskCompletionSource<Movie>();
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            if (ea.BasicProperties.CorrelationId == props.CorrelationId)
            {
                var response = Encoding.UTF8.GetString(ea.Body.ToArray());
                var movie = JsonConvert.DeserializeObject<Movie>(response);
                tcs.SetResult(movie);
            }
        };

        channel.BasicConsume(queue: replyQueueName, autoAck: true, consumer: consumer);
        return await tcs.Task;
    }
}