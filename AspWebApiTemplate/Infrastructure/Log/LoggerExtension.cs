namespace Infrastructure.Log
{
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;

    public static class LoggerExtension
    {
        /// <summary>
        /// This method initializes the Logger by the provided configuration
        /// </summary>
        /// <param name="Service">Dependency injection service</param>
        /// <param name="Config">Logger configuration</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddSeriLog(this IServiceCollection Service ,ILoggerConfiguration Config)
        {
            if (Service == null)
                throw new ArgumentNullException(nameof(Service));


        }

        /// <summary>
        /// This method initializes the logger by using the Config file
        /// </summary>
        /// <param name="Service">Dependency injection service</param>
        /// <param name="ConfigurationFileName">Logger configuration file name</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddSerilog(this IServiceCollection Service, string ConfigurationFileName)
        {
            if (Service == null)
                throw new ArgumentNullException(nameof(Service));
        }
    }
}
