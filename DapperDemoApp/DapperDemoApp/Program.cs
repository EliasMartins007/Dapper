using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using System.Data.Entity;

namespace DapperDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configurar Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/logSerilog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Iniciando demonstração Dapper CRUD...");

                var repository = new ProdutoRepository();

                // 1. Criar tabela (se não existir)
                Log.Information("Criando tabela 'Produtos' se não existir...");
                repository.CriarTabelaSeNaoExistir();
                Log.Information("Tabela 'Produtos' verificada/criada.");

                // Limpar dados de execuções anteriores para um teste limpo
                Log.Information("Limpando dados existentes da tabela Produtos...");
                var todosParaLimpeza = repository.ObterTodosProdutos();
                foreach (var pDel in todosParaLimpeza)
                {
                    repository.ExcluirProduto(pDel.Id);
                }
                Log.Information("Dados limpos.");

                // 2. Adicionar produtos
                Log.Information("Adicionando novos produtos...");
                var produto1 = new Produto { Nome = "Laptop Gamer", Preco = 7500.99m };
                var produto2 = new Produto { Nome = "Mouse Sem Fio", Preco = 120.50m };
                var produto3 = new Produto { Nome = "Teclado Mecânico RGB", Preco = 450.00m };

                repository.AdicionarProduto(produto1);
                repository.AdicionarProduto(produto2);
                repository.AdicionarProduto(produto3);

                Log.Information("Produto adicionado: {Produto}", produto1);
                Log.Information("Produto adicionado: {Produto}", produto2);
                Log.Information("Produto adicionado: {Produto}", produto3);

                // 3. Obter todos os produtos
                Log.Information("Listando todos os produtos:");
                List<Produto> todosProdutos = repository.ObterTodosProdutos();
                if (todosProdutos.Any())
                {
                    foreach (var p in todosProdutos)
                    {
                        Log.Information("{Produto}", p);
                    }
                }
                else
                {
                    Log.Warning("Nenhum produto encontrado.");
                }

                // 4. Obter um produto por ID
                Log.Information("Obtendo produto com Id = {Id}", produto1.Id);
                Produto produtoEncontrado = repository.ObterProdutoPorId(produto1.Id);
                if (produtoEncontrado != null)
                {
                    Log.Information("Produto encontrado: {Produto}", produtoEncontrado);
                }
                else
                {
                    Log.Warning("Produto com Id = {Id} não encontrado.", produto1.Id);
                }

                // 5. Atualizar um produto
                if (produtoEncontrado != null)
                {
                    Log.Information("Atualizando produto com Id = {Id}...", produtoEncontrado.Id);
                    produtoEncontrado.Nome = "Laptop Gamer Pro (Atualizado)";
                    produtoEncontrado.Preco = 7999.99m;
                    if (repository.AtualizarProduto(produtoEncontrado))
                    {
                        Log.Information("Produto atualizado com sucesso!");
                        Log.Information("Novo estado: {Produto}", repository.ObterProdutoPorId(produtoEncontrado.Id));
                    }
                    else
                    {
                        Log.Error("Falha ao atualizar o produto.");
                    }
                }

                // 6. Excluir um produto
                Log.Information("Excluindo produto com Id = {Id}...", produto2.Id);
                if (repository.ExcluirProduto(produto2.Id))
                {
                    Log.Information("Produto excluído com sucesso!");
                }
                else
                {
                    Log.Error("Falha ao excluir o produto.");
                }

                // 7. Listar todos os produtos novamente
                Log.Information("Listando todos os produtos após atualizações e exclusões:");
                todosProdutos = repository.ObterTodosProdutos();
                if (todosProdutos.Any())
                {
                    foreach (var p in todosProdutos)
                    {
                        Log.Information("{Produto}", p);
                    }
                }
                else
                {
                    Log.Warning("Nenhum produto encontrado.");
                }

                Log.Information("Demonstração Dapper CRUD concluída.");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erro fatal durante a execução da aplicação.");
            }
            finally
            {
                Log.Information("Encerrando aplicação. Pressione qualquer tecla para sair...");
                Console.ReadKey();
                Log.CloseAndFlush();
            }
        }
    }
}

