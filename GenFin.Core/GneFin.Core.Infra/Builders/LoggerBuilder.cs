using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace GenFin.Core.Infra.Builders
{
    public static class LoggerBuilder
    {
        public static LoggingConfiguration ConfigureLogger()
        {
            var config = new LoggingConfiguration();

            var alvo = new FileTarget( "logarquivo" )
            {
                FileName = $@"{AppContext.BaseDirectory}\Logs\{DateTime.Now.ToString( "dd-MM-yyyy" )}.log",
                Layout = Layout.FromString( "${longdate} ${uppercase:${level}} * ${message} * ${exception:format=StackTrace}${newline}" )
            };

            config.AddRule( LogLevel.Info, LogLevel.Fatal, alvo );

            return config;
        }

        public static ILogger BuildLogger()
        {
            LogManager.Configuration = ConfigureLogger();
            return LogManager.GetCurrentClassLogger();
        }
    }
}