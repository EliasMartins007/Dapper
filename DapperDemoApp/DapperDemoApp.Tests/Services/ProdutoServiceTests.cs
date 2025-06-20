using DapperDemoApp.Services;
using NUnit.Framework;

namespace DapperDemoApp.Tests
{
    [TestFixture]
    public class ProdutoServiceTests
    {
        [Test]
        public void InserirProdutosDeApiMock_DeveExecutarSemErro()
        {
            var service = new ProdutoService();

            Assert.DoesNotThrow(() => service.InserirProdutosDeApiMock());
        }
    }
}
