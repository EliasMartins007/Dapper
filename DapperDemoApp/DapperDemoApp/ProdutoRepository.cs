using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperDemoApp
{
    public class ProdutoRepository
    {
        private string _connectionString;
        //private IDbConnection Connection => new SqlConnection("sua_connection_string");
        public ProdutoRepository()
        {
            // Get connection string from App.config
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);


        //teste 11/06
        public void CriarTabelaSeNaoExistir()
        {
            try
            {
                using (var db = Connection)
                {
                    string sql = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Produtos' AND xtype='U')
                CREATE TABLE Produtos (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    Nome NVARCHAR(100) NOT NULL,
                    Preco DECIMAL(18, 2) NOT NULL
                )
            ";
                    db.Execute(sql);
                    Log.Information("Tabela 'Produtos' verificada/criada com sucesso.");
                }
            }
            catch (Exception ex)
            {
                // Aqui você pode registrar o erro, lançar novamente ou tratar de forma apropriada
                Console.WriteLine("Erro ao criar tabela Produtos: " + ex.Message);
                Log.Error(ex, "Erro ao criar/verificar a tabela 'Produtos'");
                // Se necessário, relance a exceção:
                // throw;
                // Se quiser propagar a exceção para cima, descomente a linha abaixo:
                // throw;
            }
        }

        //fim teste 




        public int AdicionarProduto(Produto produto)
        {
            using (var db = Connection)
            {
                string sql = @"INSERT INTO Produtos (Nome, Preco) VALUES (@Nome, @Preco);
                                SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = db.Query<int>(sql, produto).Single();
                produto.Id = id;
                return id;
            }
        }

        public Produto ObterProdutoPorId(int id)
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Produtos WHERE Id = @Id";
                return db.QueryFirstOrDefault<Produto>(sql, new { Id = id });
            }
        }

        public List<Produto> ObterTodosProdutos()
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Produtos";
                return db.Query<Produto>(sql).ToList();
            }
        }

        public bool AtualizarProduto(Produto produto)
        {
            using (var db = Connection)
            {
                string sql = "UPDATE Produtos SET Nome = @Nome, Preco = @Preco WHERE Id = @Id";
                return db.Execute(sql, produto) > 0;
            }
        }

        public bool ExcluirProduto(int id)
        {
            using (var db = Connection)
            {
                string sql = "DELETE FROM Produtos WHERE Id = @Id";
                return db.Execute(sql, new { Id = id }) > 0;
            }
        }
    }
}
