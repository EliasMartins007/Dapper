using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DapperDemoApp.Models;

namespace DapperDemoApp
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
       : base("DefaultConnection")//("name=MinhaConexaoEF") // nome definido no App.config
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
       //public DbSet<Produto> Produtos { get; set; }//
    }
}
