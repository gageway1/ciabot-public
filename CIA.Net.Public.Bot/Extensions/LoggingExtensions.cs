using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CIA.Net.Public.Bot.Extensions
{
    public static class LoggingExtensions
    {
        public static ConfigurationBuilder UseSerilog(
            this ConfigurationBuilder builder,
            Action<ConfigurationBuilder, LoggerConfiguration> configureLogger)
        {
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration();
            configureLogger(builder, loggerConfiguration);
            Serilog.Core.Logger logger = loggerConfiguration.CreateLogger();
            //builder.Services.AddLogging(lb => lb.ClearProviders());
            //builder.Logging.AddSerilog(logger);
            //builder.Services.AddSingleton<Serilog.ILogger>(logger);

            return builder;
        }

    }

}