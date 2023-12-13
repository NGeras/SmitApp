# Movie Database Application

This is a movie database application that includes a front-end built with WPF using the MVVM pattern and a back-end implemented as a Windows service. Communication between the front-end and back-end is achieved through RabbitMQ.

## Technologies Used

- C#.NET 6
- WPF (Windows Presentation Foundation)
- RabbitMQ
- Windows Service

## Project Structure

The project is structured into front-end and back-end components:

### Front-end (WPF Application)

- **Views:** Includes XAML files for the list of movies and movie details.
- **ViewModels:** Implements MVVM pattern with view models for movies list and movie details.
- **Models:** Defines data models for movies and categories.

### Back-end (Windows Service)

- **Program.cs:** Entry point for the Windows service.
- **MovieServiceHostedService.cs:** Background service responsible for handling RabbitMQ message consumers.
- **MovieListConsumer.cs:** RabbitMQ consumer for handling movie list requests.
- **MovieDetailsConsumer.cs:** RabbitMQ consumer for handling movie details requests.
- **MovieService.cs:** Business logic service for retrieving movie data.
- **MoviesRepository.cs:** Repository class for accessing movie data (e.g., from a database).

## How to Run

1. Build the solution using Visual Studio or your preferred IDE.
2. Ensure RabbitMQ is installed and running.
3. Start the back-end Windows service.
4. Run the WPF application for the front-end.

## Configuration

- RabbitMQ server details can be configured in the RabbitMQ connection settings within the code.

## Unit Tests

The project includes unit tests for the `MovieService` methods. These tests use the MSTest framework and Moq for mocking.

To run the tests, use your preferred test runner.

## Contributing

If you'd like to contribute to the project, please follow the standard GitHub flow: Fork the repository, create a branch, make changes, and submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).