
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVarejo
{
    internal class Produto
    {
        public string Nome;  // atributos
        public double Preco;
        public int Quantidade;

        public double ValorTotalEmEstoque() // método
        {
            return Preco * Quantidade;
        }

        public void AumentaQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }

        public void DiminuiQuantidae(int quantidade)
        {
            Quantidade -= quantidade;
        }
        public override string ToString() // o método é referencia a classe Object, convertento toda o seu retorno em string
        {
            return $"{Nome}  R$ {Preco}, {Quantidade} unidades, Total: R${ValorTotalEmEstoque()} ";
        }
    }
}
