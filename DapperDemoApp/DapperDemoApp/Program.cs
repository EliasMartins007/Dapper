
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace DapperDemoApp
{
       
     class Program
{
    static async Task Main(string[] args)
    {
            //ConfigurarLogger();
            ILogConfiguracao logConfiguracao = new SerilogConfiguracao();
            logConfiguracao.Configurar();


        try
        {
            Log.Information("Iniciando execução...");

            string resultado = await ObterUsuariosDaApiAsync();
            InserirProdutos();

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

    //static void ConfigurarLogger()
    //{
    //    Log.Logger = new LoggerConfiguration()
    //        .WriteTo.Console()
    //        .WriteTo.File("logs/logSerilog.txt", rollingInterval: RollingInterval.Day)
    //        .CreateLogger();
    //}

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
