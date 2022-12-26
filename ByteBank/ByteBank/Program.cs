using ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace Main
    {
    class Program
    {
        static void Main(string[] args)
        {
            Operacoes p = new Operacoes();

            
            while (true)
            {
                Console.WriteLine("Digite a opção desejada");
                Console.WriteLine("1 - Fazer depósito");
                Console.WriteLine("2 - Fazer saque");
                Console.WriteLine("3 - Fazer transferência");

                int opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.WriteLine("Digite o valor desejado para o depósito");
                    double valorDeposito = double.Parse(Console.ReadLine());

                    p.depositar(valorDeposito);
                }
                else if (opcao == 2)
                {
                    Console.Write("Digite o valor desejado para saque");
                    double saque = double.Parse(Console.ReadLine());

                    if (p.conta < saque)
                    {
                        Console.WriteLine("Você não possui saldo suficiente");
                    }
                    else
                    {                       
                        p.Saque(saque);
                    }
                }
            }
            

    

        }

        
        
    }
}
   

        

    
