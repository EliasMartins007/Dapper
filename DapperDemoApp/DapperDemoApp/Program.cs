
using DapperDemoApp.Controllers;
using DapperDemoApp.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DapperDemoApp.Models;

namespace DapperDemoApp
{

    class Program
{
    static async Task Main(string[] args)
    {
            ILogConfiguracao logConfiguracao = new SerilogConfiguracao();
            logConfiguracao.Configurar();
        try
        {
            Log.Information("Iniciando execução...");
            string resultado = await ObterUsuariosDaApiAsync();
                //InserirProdutos();
                //teste 20/06
                var controller = new ProdutoController(new ProdutoService());
                controller.InserirProdutosDeExemplo();
                /// fim 


                Log.Information("Produtos inseridos com sucesso após chamada da API.");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Erro fatal durante execução.");
        }
        finally
        {
            EncerrarAplicacao();
        }
    }

    static async Task<string> ObterUsuariosDaApiAsync()
    {
        var service = new UsuarioService();
        string resultado = await service.ObterUsuariosAsync();
        Log.Information("Resultado da API: {Resultado}", resultado);
        return resultado;
    }

    static void InserirProdutos()
    {
        var repository = new ProdutoRepository();
        repository.CriarTabelaSeNaoExistir();
        var produtos = new List<Produto>
        {
            new Produto { Nome = "API Result - 1", Preco = 199.99m },
            new Produto { Nome = "API Result - 2", Preco = 299.99m }
        };

        foreach (var produto in produtos)
        {
            repository.AdicionarProduto(produto);
        }
    }

    static void EncerrarAplicacao()
    {
        Log.Information("Finalizando aplicação. Pressione uma tecla para sair...");
        Console.ReadKey();
        Log.CloseAndFlush();
    }
}
}
