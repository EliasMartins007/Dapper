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


        //


        [Test]
        [Category("Configuração")]
        [Description("Verifica se o método Configurar() é chamado exatamente uma vez")]
        public void Configurar_DeveSerChamado_UmaVez()
        {
            // Arrange
            var mockLogger = new Mock<ILogConfiguracao>();

            // Act
            mockLogger.Object.Configurar();

            // Assert
            mockLogger.Verify(x => x.Configurar(), Times.Once, "O método Configurar não foi chamado o número esperado de vezes");
        }


        [Test]
        [Category("Configuração")]
        [Description("Verifica se o método Configurar() não é chamado, quando não executado")]
        public void Configurar_NaoDeveSerChamado_QuandoNaoExecutado()
        {
            // Arrange
            var mockLogger = new Mock<ILogConfiguracao>();

            // Act (não chamamos Configurar())

            // Assert
            mockLogger.Verify(x => x.Configurar(), Times.Never);
        }

    }
}
