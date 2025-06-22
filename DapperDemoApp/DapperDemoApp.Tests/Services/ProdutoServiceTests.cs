using DapperDemoApp.Services;
using NUnit.Framework;

namespace DapperDemoApp.Tests
{
    [TestFixture]
    public class ProdutoServiceTests
    {
        [Test]
        [Description("Simulação de inserção de um produto")]
        [Category("Simulação")]
        public void InserirProdutosDeApiMock_DeveExecutarSemErro()
        {
            var service = new ProdutoService();

            Assert.DoesNotThrow(() => service.InserirProdutosDeApiMock());
        }
    }
}
