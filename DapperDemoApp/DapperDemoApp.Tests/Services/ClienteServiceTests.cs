using DapperDemoApp.Models;
using DapperDemoApp.Services;
using NUnit.Framework;

namespace DapperDemoApp.Tests
{
    [TestFixture]
    public class ClienteServiceTests
    {
        private ClienteService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ClienteService();
        }

        [Test]
        public void Adicionar_DeveAdicionarCliente()
        {
            var cliente = new Cliente { Nome = "Elias", Email = "elias@email.com" };

            _service.Adicionar(cliente);
            var resultado = _service.ObterTodos();

            //Assert.AreEqual(1, resultado.Count());
            //Assert.AreEqual("Elias", resultado.First().Nome);
        }

        [Test]
        public void Atualizar_DeveAlterarDadosDoCliente()
        {
            var cliente = new Cliente { Nome = "Antigo", Email = "a@a.com" };
            _service.Adicionar(cliente);

            var atualizado = new Cliente { Nome = "Novo", Email = "novo@email.com" };
            var sucesso = _service.Atualizar(1, atualizado);

            //Assert.IsTrue(sucesso);
            //Assert.AreEqual("Novo", _service.ObterPorId(1).Nome);
        }

        [Test]
        public void Remover_DeveExcluirCliente()
        {
            _service.Adicionar(new Cliente { Nome = "elias", Email = "eliasteste@gmail.com" });

            var sucesso = _service.Remover(1);
            //Assert.IsTrue(sucesso);
            //Assert.IsNull(_service.ObterPorId(1));
        }



    }
}

