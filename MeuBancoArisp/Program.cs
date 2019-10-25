using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuBancoArisp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            * Sistema Bancário
           */

            //Variáveis
            int agencia = 0;
            int conta = 0;
            string nomeDoTitular = string.Empty;
            string tipoConta;
            double saldo = 0.00;
            double depositoSaque = 0.00;
            string depositoInicial;
            string operacao;
            string tipoOperacao;
            string nomeDoBanco = "Banco .NET";


            //Input dados
            Console.WriteLine("------Bem vindo ao Banco {0}-------", nomeDoBanco);

            Console.Write("Informe o número da Agência: ");
            agencia = int.Parse(Console.ReadLine());
            Console.Write("Informe o número da Conta: ");
            conta = int.Parse(Console.ReadLine());
            Console.Write("Informe o número do Nome do Titular da Conta: ");
            nomeDoTitular = Console.ReadLine();
            Console.Write("Informe o Tipo da Conta: P => Poupanca / C => Conta Corrente ");
            tipoConta = Console.ReadLine();
            Console.Write("Deseja fazer um depósito inicial? S=> Sim / N=> Não ");
            depositoInicial = Console.ReadLine();

            if (depositoInicial.ToLower() == "s")
            {
                Console.Write("Informe o valor de depósito: ");
                saldo = Convert.ToDouble(Console.ReadLine());
            };
        }
    }
}
