using DapperDemoApp.Models;
using DapperDemoApp.Services;
using System;

namespace DapperDemoApp.Controllers
{
    public class ClienteController
    {
        private readonly ClienteService _service;

        public ClienteController()
        {
            _service = new ClienteService();
        }

        public void Executar()
        {
            _service.Adicionar(new Cliente { Nome = "Elias", Email = "elias@email.com" });
            foreach (var cliente in _service.ObterTodos())
            {
                Console.WriteLine($"Cliente: {cliente.Id} - {cliente.Nome} - {cliente.Email}");
            }
        }
    }
}