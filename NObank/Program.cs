using System;
using System.Collections.Generic;

namespace NObank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                 switch (opcaoUsuario)
                 {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                 }
                 opcaoUsuario = ObterOpcaoUsuario();
            }            
            Console.WriteLine("Obrigado por utilizar o NObank!");
        }

        private static void Transferir()
        {
            Console.WriteLine("Realizar Transferência");
            Console.WriteLine();
            Console.Write("Informar o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            
            Console.Write("Informar o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Informar o valor a ser transferido: ");
            int valorTransferencia = int.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia,listaContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Realizar Depósito");
            Console.WriteLine();
            Console.Write("Informar o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Informar o valor do depósito: ");
            int valorDeposito = int.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Realizar Saque");
            Console.WriteLine();
            Console.Write("Informar o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Informar o valor do saque: ");
            int valorSaque = int.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);   
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.Write("Digite 1 para Pessoa Física ou 2 para Pessoa Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao NObank");
            Console.WriteLine("Oque deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
