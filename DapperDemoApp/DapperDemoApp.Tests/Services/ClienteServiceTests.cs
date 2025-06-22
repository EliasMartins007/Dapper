using DapperDemoApp.Models;
using DapperDemoApp.Services;
using Moq;
using NUnit.Framework;
using System.Linq;

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
        public void Adicionar_DeveAdicionarCliente_QuandoDadosValidos()
        {
            // Arrange
            var cliente = new Cliente { Nome = "Elias", Email = "elias@email.com" };
            int quantidadeInicial = _service.ObterTodos().Count();

            // Act
            _service.Adicionar(cliente);
            var resultado = _service.ObterTodos();
            var clienteAdicionado = resultado.Last(); // Ou First() se for o único

            // Assert
            Assert.That(resultado.Count(), Is.EqualTo(quantidadeInicial + 1), "Deveria ter incrementado a quantidade de clientes");
            Assert.That(clienteAdicionado.Nome, Is.EqualTo(cliente.Nome), "Nome do cliente não corresponde");
            Assert.That(clienteAdicionado.Email, Is.EqualTo(cliente.Email), "Email do cliente não corresponde");
            // Adicione outras propriedades relevantes para verificar
        }

        //[Test]
        //public void Adicionar_DeveChamarMetodoRepositorio_QuandoDadosValidos()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IClienteRepository>();
        //    var service = new ClienteService(mockRepo.Object);
        //    var cliente = new Cliente { Nome = "Elias", Email = "elias@email.com" };

        //    // Act
        //    service.Adicionar(cliente);

        //    // Assert
        //    mockRepo.Verify(r => r.Adicionar(cliente), Times.Once);
        //}
        //

        //[Test]
        //[Description("Verifica se o cliente é adicionado corretamente ao repositório")]
        //public void Adicionar_ClienteValido_DeveSerPersistido() { ... }

        //[Test]
        //[Category("Integracao")]
        //[Category("BancoDeDados")]
        //public void Adicionar_ClienteValido_DeveSerPersistidoNoBanco() { ... }




















        //

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
            _service.Adicionar(new Cliente { Nome = "elias", Email = "eliastes@gmail.com" });

            var sucesso = _service.Remover(1);
            //Assert.IsTrue(sucesso);
            //Assert.IsNull(_service.ObterPorId(1));
        }
        //[Test]
        //public void Remover_QuandoIdExistir_DeveChamarRepositorio()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IClienteRepository>();
        //    mockRepo.Setup(x => x.Existe(1)).Returns(true);
        //    var service = new ClienteService(mockRepo.Object);

        //    // Act
        //    var resultado = service.Remover(1);

        //    // Assert
        //    Assert.IsTrue(resultado);
        //    mockRepo.Verify(x => x.Remover(1), Times.Once);
        //    mockRepo.Verify(x => x.Salvar(), Times.Once);
        //}


    }
}

