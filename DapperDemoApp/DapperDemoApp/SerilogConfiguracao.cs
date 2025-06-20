using Serilog;

namespace DapperDemoApp
{
    internal class SerilogConfiguracao : ILogConfiguracao
    {
        public void Configurar()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/logSerilog.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }
    }
}
