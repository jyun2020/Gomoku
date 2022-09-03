using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gomoku
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

            var services = new ServiceCollection();

            ConfigureServices(services,config);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var form = serviceProvider.GetRequiredService<Form>();
                //ApplicationConfiguration.Initialize();
                Application.Run(form);
            }
        }
        private static void ConfigureServices(ServiceCollection services, IConfiguration config)
        {
            services.AddScoped<Form>();
            services.AddOptions<GameSettings>().Bind(config.GetSection("GameSettings"));
        }
    }
}