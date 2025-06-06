using System;
using System.Collections.Generic;
using System.Linq;

namespace DapperDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando demonstração Dapper CRUD...");

            var repository = new ProdutoRepository();

            // 1. Criar tabela (se não existir)
            Console.WriteLine("Criando tabela 'Produtos' se não existir...");
            repository.CriarTabelaSeNaoExistir();
            Console.WriteLine("Tabela 'Produtos' verificada/criada.");

            // Limpar dados de execuções anteriores para um teste limpo
            Console.WriteLine("Limpando dados existentes da tabela Produtos...");
            var todosParaLimpeza = repository.ObterTodosProdutos();
            foreach (var pDel in todosParaLimpeza)
            {
                repository.ExcluirProduto(pDel.Id);
            }
            Console.WriteLine("Dados limpos.");


            // 2. Adicionar produtos
            Console.WriteLine("\nAdicionando novos produtos...");
            var produto1 = new Produto { Nome = "Laptop Gamer", Preco = 7500.99m };
            var produto2 = new Produto { Nome = "Mouse Sem Fio", Preco = 120.50m };
            var produto3 = new Produto { Nome = "Teclado Mecânico RGB", Preco = 450.00m };

            repository.AdicionarProduto(produto1); // produto1.Id will be updated
            repository.AdicionarProduto(produto2);
            repository.AdicionarProduto(produto3);
            Console.WriteLine($"Produto adicionado: {produto1}");
            Console.WriteLine($"Produto adicionado: {produto2}");
            Console.WriteLine($"Produto adicionado: {produto3}");

            // 3. Obter todos os produtos
            Console.WriteLine("\nListando todos os produtos:");
            List<Produto> todosProdutos = repository.ObterTodosProdutos();
            if (todosProdutos.Any())
            {
                foreach (var p in todosProdutos)
                {
                    Console.WriteLine(p);
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto encontrado.");
            }

            // 4. Obter um produto por ID
            Console.WriteLine($"\nObtendo produto com Id = {produto1.Id}:");
            Produto produtoEncontrado = repository.ObterProdutoPorId(produto1.Id);
            if (produtoEncontrado != null)
            {
                Console.WriteLine($"Produto encontrado: {produtoEncontrado}");
            }
            else
            {
                Console.WriteLine($"Produto com Id = {produto1.Id} não encontrado.");
            }

            // 5. Atualizar um produto
            if (produtoEncontrado != null)
            {
                Console.WriteLine($"\nAtualizando produto com Id = {produtoEncontrado.Id}...");
                produtoEncontrado.Nome = "Laptop Gamer Pro (Atualizado)";
                produtoEncontrado.Preco = 7999.99m;
                if (repository.AtualizarProduto(produtoEncontrado))
                {
                    Console.WriteLine("Produto atualizado com sucesso!");
                    Console.WriteLine($"Novo estado: {repository.ObterProdutoPorId(produtoEncontrado.Id)}");
                }
                else
                {
                    Console.WriteLine("Falha ao atualizar o produto.");
                }
            }

            // 6. Excluir um produto
            Console.WriteLine($"\nExcluindo produto com Id = {produto2.Id}...");
            if (repository.ExcluirProduto(produto2.Id))
            {
                Console.WriteLine("Produto excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao excluir o produto.");
            }

            // 7. Listar todos os produtos novamente para ver as alterações
            Console.WriteLine("\nListando todos os produtos após atualizações e exclusões:");
            todosProdutos = repository.ObterTodosProdutos();
            if (todosProdutos.Any())
            {
                foreach (var p in todosProdutos)
                {
                    Console.WriteLine(p);
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto encontrado.");
            }

            Console.WriteLine("\nDemonstração Dapper CRUD concluída.");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
