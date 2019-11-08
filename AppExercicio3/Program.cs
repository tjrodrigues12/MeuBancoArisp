using System;

namespace AppExercicio3
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

            do
            {
                Console.Write("Deseja fazer uma nova operação? S=> Sim / N=> Não: ");
                operacao = Console.ReadLine();

                if (operacao.ToLower() == "n")
                    continue;

                Console.Write("Escolha qual operação deseja realizar: D=> Depósito / S=> Saque: ");
                tipoOperacao = Console.ReadLine();

                switch (tipoOperacao)
                {
                    case "d":

                        Console.Write("Informe o valor de depósito:");
                        saldo += Convert.ToDouble(Console.ReadLine());

                        break;

                    case "s":

                        Console.Write("Informe o valor de saque:");
                        var valor = Convert.ToDouble(Console.ReadLine());

                        if (saldo >= valor)
                        {
                            saldo -= valor;
                        }
                        else
                        {
                            Console.WriteLine("Você não tem saldo suficiente!");
                        }

                        break;

                    default:

                        break;
                }

            } while (operacao.ToLower() != "n");

            Console.Clear();
            Console.WriteLine($"------ Bem vindo ao Banco {nomeDoBanco} -------");
            Console.WriteLine($"Número da Agência: {agencia}");         
            Console.WriteLine($"Número da Conta: {conta}");            
            Console.WriteLine($"Nome do Titular da Conta: {nomeDoTitular}");           
            Console.WriteLine($"Tipo da Conta: {(tipoConta == "c" ? "Conta Corrente" : "Poupança")}");
            Console.WriteLine($"Saldo: {saldo}");
            Console.ReadKey();

        }
    }
}
