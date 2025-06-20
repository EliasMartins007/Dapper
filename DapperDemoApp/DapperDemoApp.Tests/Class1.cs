using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DapperDemoApp.Tests
{

    [TestFixture]
    public class ExemploTests
    {
        [Test]
        public void TesteSimples_DevePassar()
        {
            //Assert.AreEqual(2 + 2, 4);
        }


        //[Test]
        //public async Task ObterUsuariosDaApiAsync_DeveRetornarResultado()
        //{
        //    // Arrange
        //    var service = new UsuarioService();

        //    // Act
        //    string resultado = await service.ObterUsuariosAsync();

        //    // Assert
        //    Assert.IsNotNull(resultado);
        //    Assert.IsNotEmpty(resultado);
        //}

        //[Test]
        //public void InserirProdutos_DeveExecutarSemErros()
        //{
        //    // Arrange
        //    var repo = new ProdutoRepository();
        //    repo.CriarTabelaSeNaoExistir();

        //    // Act & Assert
        //    Assert.DoesNotThrow(() =>
        //    {
        //        repo.AdicionarProduto(new Produto { Nome = "Teste", Preco = 10.0m });
        //    });
        //}


    }
}
