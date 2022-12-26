using LojaVarejo;
using System;
namespace main { 

    class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto(); // criação de uma variável com os tres atributos a classe Produto

            Console.WriteLine("Entre com os dados do produto");
            Console.Write("Nome: ");
            p.Nome = Console.ReadLine();

            Console.Write("Preço: ");
            p.Preco = double.Parse(Console.ReadLine());

            Console.Write("Quantidade no estoque: ");
            p.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine(p);
            Console.WriteLine();

            int aumento;
            Console.WriteLine("Digite o número de produtos a ser adicionado ao estoque: ");
            aumento = int.Parse(Console.ReadLine());
            p.AumentaQuantidade(aumento);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {p}");

            Console.WriteLine();
            Console.WriteLine("Digite o número de produtos a ser removido ao estoque: ");
            int diminui = int.Parse(Console.ReadLine());

            Console.WriteLine();
            p.DiminuiQuantidae(diminui);
            Console.WriteLine($"Dados atualizados: {p}");


        }
    }


}