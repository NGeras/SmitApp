
## Movie Database Application

This is a movie database application that includes a front-end built with WPF using the MVVM pattern and a back-end implemented as a Windows service. Communication between the front-end and back-end is achieved through RabbitMQ.

## Technologies Used

- WPF (.NET 6)
- RabbitMQ
- Windows Service (.NET Framework 4.8) or Worker Service (.NET 6)

## Project Structure

The project is structured into front-end and back-end components:

### Front-end (WPF Application)

- **Views:** Includes XAML files for the list of movies and movie details.
- **ViewModels:** Implements MVVM pattern with view models for movies list and movie details.
### Core (.NET Standard2.0)

- **MovieService.cs:** Business logic service for retrieving movie data.
- **MoviesRepository.cs:** Repository class for accessing movie data (e.g., from a database, hardcoded right now).
- **CategoryService.cs:** Business logic service for retrieving category data.
- **CategoryRepository.cs:** Repository class for accessing category data (e.g., from a database, hardcoded right now).

### Models (.NET Standard2.0)

- **Models:** Defines data models for movies and categories for front-end and back-end.

### Back-end (Windows Service .NET Framework 4.8)

- **Program.cs:** Entry point for the Windows service.
- **SmitService.cs:** Background service responsible for handling RabbitMQ message consumers using MovieService and CategoryService.

### Back-end (Worker Service .NET 6)

- **Program.cs:** Entry point for the Windows service.
- **Worker.cs:** Background service responsible for handling RabbitMQ message consumers using MovieService and CategoryService.

## How to Run

1. Build the solution using Visual Studio or your preferred IDE.
2. Ensure RabbitMQ is installed and running.
3. Start the back-end Windows service.
* For **.NET Framework** service:
	1. Open Developer Command Prompt for Visual Studio with administrative credentials.
	2. In Developer Command Prompt for Visual Studio, navigate to the folder that contains your project's output.
	3. Enter the following command
	```
	installutil SmitApp.Backend.exe
	```
	4. Start "Smit Service" service from Services app in Windows	
* For **.NET 6** Worker service:
	1. Publish the app using
	```
	dotnet publish --output "C:\custom\publish\directory"
	```
	2. Create the Windows Service with PowerShell
	```
	sc.exe create "Smit Service" binpath="C:\Path\To\SmitApp.BackendWorker.exe"
	```
	3. Start "Smit Service" service from Services app in Windows
	
4. Run the WPF application for the front-end.

## Configuration

- RabbitMQ server details can be configured in the RabbitMQ connection settings within the code.

## Unit Tests

The project includes unit tests for the `MovieService` methods. These tests use the MSTest framework and Moq for mocking.

To run the tests, use your preferred test runner.

## License

This project is licensed under the [MIT License](LICENSE).
