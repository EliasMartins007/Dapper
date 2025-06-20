using DapperDemoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoApp.Controllers
{
    public class ProdutoController
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController()
        {
            _produtoService = new ProdutoService();
        }

        // Construtor que aceita um ProdutoService como argumento
        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public void InserirProdutosDeExemplo()
        {
            _produtoService.InserirProdutosDeApiMock();
        }
    }
}
