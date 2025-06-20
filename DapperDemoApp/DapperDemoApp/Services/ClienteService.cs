using System.Collections.Generic;
using DapperDemoApp.Models;


namespace DapperDemoApp.Services
{
    public class ClienteService
    {
        //private readonly List<Cliente> _clientes = new(); // .NET 5
        private readonly List<Cliente> _clientes = new List<Cliente>();// 4.8 
        public IEnumerable<Cliente> ObterTodos() => _clientes;

        public Cliente ObterPorId(int id) => _clientes.Find(c => c.Id == id);

        public void Adicionar(Cliente cliente)
        {
            cliente.Id = _clientes.Count + 1;
            _clientes.Add(cliente);
        }

        public bool Atualizar(int id, Cliente clienteAtualizado)
        {
            var cliente = ObterPorId(id);
            if (cliente == null) return false;

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;
            return true;
        }

        public bool Remover(int id)
        {
            var cliente = ObterPorId(id);
            return cliente != null && _clientes.Remove(cliente);
        }
    }
}