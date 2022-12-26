using Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    internal class Operacoes
    {


        public double conta = 0;

        
        public void depositar(double deposito)
        {
            conta += deposito;
            Console.WriteLine(conta);
        }

        public void Saque(double saque)
        {
            conta -= saque;
            Console.WriteLine(conta);
        }

       

    }
}
