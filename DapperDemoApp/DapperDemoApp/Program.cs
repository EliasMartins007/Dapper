
//using DapperDemoApp.Controllers;
//using DapperDemoApp.Services;
//using Serilog;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.Entity;
//using System.Threading.Tasks;

//namespace DapperDemoApp
//{

//    public class Program
//    {
//        public static async Task Main(string[] args)
//        {
//            ILogConfiguracao logConfiguracao = new SerilogConfiguracao();
//            logConfiguracao.Configurar();


//            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());






//            try
//            {
//                Log.Information("Iniciando execução...");
//                string resultado = await ObterUsuariosDaApiAsync();
//                //InserirProdutos();
//                //teste 20/06
//                var controller = new ProdutoController(new ProdutoService());
//                controller.InserirProdutosDeExemplo();
//                /// fim 


//                Log.Information("Produtos inseridos com sucesso após chamada da API.");
//            }
//            catch (Exception ex)
//            {
//                Log.Fatal(ex, "Erro fatal durante execução.");
//            }
//            finally
//            {
//                EncerrarAplicacao();
//            }
//        }

//        static async Task<string> ObterUsuariosDaApiAsync()
//        {
//            var service = new UsuarioService();
//            string resultado = await service.ObterUsuariosAsync();
//            Log.Information("Resultado da API: {Resultado}", resultado);
//            return resultado;
//        }

//        static void InserirProdutos()
//        {
//            var repository = new ProdutoRepository();
//            repository.CriarTabelaSeNaoExistir();
//            var produtos = new List<Produto>
//        {
//            new Produto { Nome = "API Result - 1", Preco = 199.99m },
//            new Produto { Nome = "API Result - 2", Preco = 299.99m }
//        };

//            foreach (var produto in produtos)
//            {
//                repository.AdicionarProduto(produto);
//            }
//        }

//        static void EncerrarAplicacao()
//        {
//            Log.Information("Finalizando aplicação. Pressione uma tecla para sair...");
//            Console.ReadKey();
//            Log.CloseAndFlush();
//        }
//    }
//}














//

using System;
using System.Data.Entity;
using System.Threading.Tasks;
using DapperDemoApp;
using DapperDemoApp.Migrations;
using Serilog;


using DapperDemoApp.Controllers;
using DapperDemoApp.Services;
using System.Collections.Generic;





public class Program
{
    public static async Task Main(string[] args)//public static void Main(string[] args)
    {


        ILogConfiguracao logConfiguracao = new SerilogConfiguracao();
        logConfiguracao.Configurar();



        // 1. Configura o inicializador do banco de dados para usar as migrações.
        // Ele aponta para o seu DbContext e para a classe Configuration das suas migrações.
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());

        // 2. Cria uma instância do seu DbContext.
        // Ao criar a instância, o inicializador configurado acima será acionado.
        // Isso fará com que o EF verifique se o banco de dados existe e se todas as migrações
        // foram aplicadas. Se o banco não existir, ele será criado. Se houver migrações pendentes, elas serão aplicadas.
        using (var context = new AppDbContext())//SeuDbContext())
        {
            Console.WriteLine("Verificando e aplicando migrações para 'DapperDemoDB'...");
            try
            {
                // O método .Database.Initialize(true) força o DbContext a executar o inicializador.
                // Isso garante que as migrações sejam aplicadas imediatamente.
                context.Database.Initialize(true);
                Console.WriteLine("Banco de dados 'DapperDemoDB' criado/atualizado com sucesso via migrações!");

                // Agora você pode usar seu contexto para operações no banco de dados.
                // Exemplo:

                Log.Information("Iniciando execução...");
                string resultado = await ObterUsuariosDaApiAsync();
                InserirProdutos();

                //teste 20/06
                var controller = new ProdutoController(new ProdutoService());
                controller.InserirProdutosDeExemplo();

                // var clientes = context.Clientes.ToList();
                // Console.WriteLine($"Número de clientes no DB: {clientes.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao aplicar migrações: {ex.Message}");
                Console.WriteLine("Detalhes do erro:");
                Console.WriteLine(ex.ToString()); // Imprime o stack trace completo para depuração
                Log.Fatal(ex, "Erro fatal durante execução.");
            }
        }

        Console.WriteLine("Pressione qualquer tecla para sair.");
        Console.ReadKey();
    }


    //outros metodos
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