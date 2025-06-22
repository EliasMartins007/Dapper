using DapperDemoApp.Models;
using System.Data.Entity;


namespace DapperDemoApp
{

    //
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Preço: {Preco:C}";
        }
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    //fim 

    public class AppDbContext: DbContext
    {
        public AppDbContext()
       : base("DapperDBConnection")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
       // public DbSet<Produto> Produtos { get; set; }//
       // public DbSet<Produto> Usuarios { get; set; }//

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //fim
    }
}
