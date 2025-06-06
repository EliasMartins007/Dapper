using System;

namespace DapperDemoApp
{
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
}
