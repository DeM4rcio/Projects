using ByteBank;
using Microsoft.VisualBasic.FileIO;
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

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);
            Console.WriteLine(indexParaDeletar);

            if (indexParaDeletar == -1)
            {
                Console.WriteLine("Não foi possível deletar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("Conta deletada com sucesso");
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                ApresentaConta(i, cpfs, titulares, saldos);
            }
        }

        static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            if (indexParaApresentar == -1)
            {
                Console.WriteLine("Não foi possível apresentar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
            
        }

        static void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum()}");
            
        }

        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }

        static void QuantiaArmazenada(List<string> cpfs, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            Console.WriteLine($"Saldo de sua conta é de: {saldos[indexParaApresentar]} R$");
        }

        static void Operacoes(List<string> cpfs, List<double> saldos, List<string> titulares, List<string> senhas)
        {
            Console.Write("Digite o seu cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);
            if(indexParaApresentar == -1 || senha != senhas[indexParaApresentar])
            {
                Console.WriteLine("CPF ou Senha incorreta. Tente novamente.");
                

            }
            else
            {
                Console.WriteLine($"Seja Bem-Vindo {titulares[indexParaApresentar]} ao ByteBank!");
                int escolha;
                do
                {
                    Console.WriteLine("=============");
                    Console.WriteLine("1 - Fazer depósito");
                    Console.WriteLine("2 - Fazer saque");
                    Console.WriteLine("3 - Fazer Trasferência");
                    Console.WriteLine("4 - Visualizar Saldo em conta");
                    Console.WriteLine("0 - Encerrar a operação");
                    Console.Write("Digite a operação desejada:");
                    escolha = int.Parse(Console.ReadLine());
                    Console.WriteLine("=============");


                    switch (escolha)
                    {
                        case 1:
                            double valorDeposito;
                            Console.Write("O depósito será com o valor de: ");
                            valorDeposito = double.Parse(Console.ReadLine());
                            saldos[indexParaApresentar] += valorDeposito;
                            Console.WriteLine("Operação realizada com sucesso!");
                            break;
                        case 2:
                            double valorSaque;
                            Console.Write("O saque será com o valor de: ");
                            valorSaque = double.Parse(Console.ReadLine());
                            if (valorSaque > saldos[indexParaApresentar])
                            {
                                Console.WriteLine("Saldo Insuficiente");
                            }
                            else
                            {
                                saldos[indexParaApresentar] -= valorSaque;
                                Console.WriteLine("Operação realizada com sucesso!");
                            }
                            break;
                        case 3:
                           
                                
                             Console.Write("Digite o CPF da conta para a trasferência: ");

                             string cpftrasfer = Console.ReadLine();
                             int condicaoTrasfer = cpfs.FindIndex(cpf => cpf == cpftrasfer);
                             if(condicaoTrasfer == -1)
                            {
                                Console.WriteLine("CPF não encontrado");

                            }
                            else
                            {
                                int indexParaTransfer = cpfs.FindIndex(cpf => cpf == cpftrasfer);
                                Console.Write("Insira o valor desejado para a trasferência: ");
                                double valorTrasnfer = double.Parse(Console.ReadLine());

                                

                                if (saldos[indexParaApresentar] < valorTrasnfer)
                                {
                                    Console.WriteLine("Saldo Insuficiente");
                                }
                                else
                                {
                                    saldos[indexParaApresentar] -= valorTrasnfer;

                                    saldos[indexParaTransfer] += valorTrasnfer;

                                    Console.WriteLine("Operação realizada com sucesso!");
                                }

                            }
                             break;
                            case 4:
                            Console.WriteLine($"O valor em conta é: {saldos[indexParaApresentar]}R$");
                      break;







                            

                    }

                } while (escolha != 0);
            }
        }
            
        static void Main(string[] args)
        {
            Operacoes p = new Operacoes();
            
            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int option;
            int usuario;

            Console.WriteLine("Qual tipo de conta?");
            Console.Write("1 - Cliente" + " " + "2 - Funcionário");

            usuario = int.Parse(Console.ReadLine());
            if (usuario == 1)
            {

                do
                {

                    {

                    }
                    Console.WriteLine("1 - Inserir novo usuário");
                    Console.WriteLine("2 - Deletar um usuário");
                    Console.WriteLine("3 - Listar todas as contas registradas");
                    Console.WriteLine("4 - Detalhes de um usuário");
                    Console.WriteLine("5 - Quantia armazenada no banco");
                    Console.WriteLine("6 - Manipular a conta");
                    Console.WriteLine("0 - Para sair do programa");
                    Console.Write("Digite a opção desejada: ");

                    option = int.Parse(Console.ReadLine());

                    Console.WriteLine("-----------------");

                    switch (option)
                    {
                        case 0:
                            Console.WriteLine("Estou encerrando o programa...");
                            break;
                        case 1:
                            RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                            break;
                        case 2:
                            DeletarUsuario(cpfs, titulares, senhas, saldos);
                            break;
                        case 3:
                            ListarTodasAsContas(cpfs, titulares, saldos);
                            break;
                        case 4:
                            ApresentarUsuario(cpfs, titulares, saldos);
                            break;
                        case 5:
                            QuantiaArmazenada(cpfs, saldos);
                            break;
                        case 6:
                            Operacoes(cpfs, saldos, titulares, senhas);
                            break;



                    }

                    Console.WriteLine("-----------------");

                } while (option != 0);
            }else if (usuario == 1)
            {
                Console.WriteLine("Digite o Hash para acessar a conta:");

            }








        }




    }
}
   

        

    
