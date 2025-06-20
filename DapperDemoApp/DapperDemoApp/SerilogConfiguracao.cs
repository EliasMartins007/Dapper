using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
