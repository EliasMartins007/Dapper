using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoApp.Tests
{
    [TestFixture]
    public class UsuarioServiceTests
    {

        [Test]
        public async Task ObterUsuariosAsync_DeveRetornarConteudo()
        {
            // Arrange
            var service = new UsuarioService();

            // Act
            var resposta = await service.ObterUsuariosAsync();

            // Assert
            //Assert.IsNotNull(resposta);
            //Assert.IsFalse(string.IsNullOrWhiteSpace(resposta));
            Assert.That(resposta, Is.Not.Null.And.Not.Empty);
            //Assert.IsNotEmpty(resposta);
            //Assert.That(resposta, Does.Contain("name")); // Exemplo de campo esperado
        }
    }
}
