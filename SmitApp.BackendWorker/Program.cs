using SmitApp.Core.Contracts.Repositories;
using SmitApp.Core.Contracts.Services;
using SmitApp.Core.Repositories;
using SmitApp.Core.Services;

namespace SmitApp.BackendWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<IMovieRepository, MovieRepository>();
                    services.AddTransient<ICategoryRepository, CategoryRepository>();
                    services.AddTransient<IMovieService, MovieService>();
                    services.AddTransient<ICategoryService, CategoryService>();
                    services.AddHostedService<Worker>();
                    services.AddWindowsService(options =>
                    {
                        options.ServiceName = "SmitApp Service";
                    });
                })
                .Build();

            host.Run();
        }
    }
}