using DapperDemoApp.Models;
using System.Collections.Generic;

namespace DapperDemoApp.Services
{
    public interface IClienteService
    {
        IEnumerable<Cliente> ObterTodos();
        Cliente ObterPorId(int id);
        void Adicionar(Cliente cliente);
        bool Atualizar(int id, Cliente cliente);
        bool Remover(int id);
    }
}
