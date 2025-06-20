using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace DapperDemoApp.Tests
{

    [TestFixture]
    public class LoggerConfiguracaoTests
    {
        [Test]
        public void Configurar_DeveSerChamado()
        {
            // Arrange
            var mockLogger = new Mock<ILogConfiguracao>();
            // Act
            mockLogger.Object.Configurar();
            // Assert
            mockLogger.Verify(x => x.Configurar(), Times.Once);
        }


    }
}
