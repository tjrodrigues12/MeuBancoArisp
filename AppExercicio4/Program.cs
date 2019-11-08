using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            * Sistema Bancário
           */

            //Variáveis
            //int agencia = 0;
            //int numeroConta = 0;
            //string nomeDoTitular = string.Empty;
            //string tipoConta;
            //double saldo = 0.00;
            string depositoInicial;
            string operacao;
            string tipoOperacao;
            //string nomeDoBanco = "Banco .NET";


            Conta conta = new Conta();

            
            //Input dados
            Console.WriteLine($"------Bem vindo ao Banco {conta.NomeDoBanco}-------");

            conta.Agencia = int.Parse(WriteRead("Informe o número da agência: "));
            conta.NumeroConta = int.Parse(WriteRead("Informe o número da conta: "));
            conta.NomeDoTitular = WriteRead("Informe o Nome do Titular da Conta: ");
            conta.TipoConta = char.Parse(WriteRead("Informe o Tipo da Conta: P => Poupanca / C => Conta Corrente "));

            depositoInicial = WriteRead("Deseja fazer um depósito inicial? S=> Sim / N=> Não ");
            
            if (depositoInicial.ToLower() == "s")
            {                
                conta.Despositar(Convert.ToDouble(WriteRead("Informe o valor de depósito: ")));
            }

            do
            {
                operacao = WriteRead("Deseja fazer uma nova operação? S=> Sim / N=> Não: ");
                
                if (operacao.ToLower() == "n")
                    continue;

                tipoOperacao = WriteRead("Escolha qual operação deseja realizar: D=> Depósito / S=> Saque: ");

                switch (tipoOperacao)
                {
                    case "d":

                        conta.Despositar(Convert.ToDouble(WriteRead("Informe o valor de depósito:")));

                        break;

                    case "s":

                        var sucesso = conta.Sacar(Double.Parse(WriteRead("Informe o valor de saque:")));
                        if (!sucesso)
                        {
                            Console.WriteLine("Você não tem saldo suficiente!");
                        }

                        break;

                    default:

                        break;
                }

            } while (operacao.ToLower() != "n");

            Console.Clear();
            WriteLine($"------ Bem vindo ao Banco {conta.NomeDoBanco} -------");
            WriteLine($"Número da Agência: {conta.Agencia}");
            WriteLine($"Número da Conta: {conta.NumeroConta}");
            WriteLine($"Nome do Titular da Conta: {conta.NomeDoTitular}");
            WriteLine($"Tipo da Conta: {(conta.TipoConta.ToString().ToLower() == "c" ? "Conta Corrente" : "Poupança")}");
            WriteLine($"Saldo: {conta.Saldo}");
            Console.ReadKey();

        }

        static string WriteRead(string message)
        {
            Write(message);
            return Console.ReadLine();
        }

        static void Write(string message)
        {
            Console.Write(message);            
        }

        static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

    }
}
