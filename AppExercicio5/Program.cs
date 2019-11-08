using System;
using System.Collections.Generic;
using System.Linq;

using AppExercicio5.Domain;
using AppExercicio5.Util;

namespace AppExercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Conta> listaContas = new List<Conta>();
            TipoOperacao tipoOperacao;

            do
            {
                Console.Clear();

                Write($"------Bem vindo ao Banco {Banco.ObterNomeBanco()}-------");
                Write("Selecione uma operação que deseja realizar:");
                Write("A => Abertura de conta");
                Write("M => Movimentações");
                Write("L => Listar Contas");
                Write("T => Transferência");
                Write("S => Sair do programa");
                Console.Write("=> ");

                tipoOperacao = (TipoOperacao)char.Parse(Console.ReadLine().ToUpper());

                switch (tipoOperacao)
                {
                    case TipoOperacao.AberturaConta:
                        var conta = AberturaDeConta();
                        listaContas.Add(conta);
                        break;

                    case TipoOperacao.Movimentacao:
                        Movimentar(listaContas);
                        break;

                    case TipoOperacao.ListarContas:
                        ListarContas(listaContas);
                        break;

                    case TipoOperacao.Transferencia:
                        Transferir(listaContas);
                        break;

                    case TipoOperacao.SairDoPrograma:
                        tipoOperacao = TipoOperacao.SairDoPrograma;
                        break;

                    default:

                        break;
                }

            } while (tipoOperacao != TipoOperacao.SairDoPrograma);
        }

        static void ApresentarDadosConta(Conta conta)
        {
            //It will be needed to implement the method here
        }

        static Conta AberturaDeConta()
        {

            TipoConta tipoConta;
            Conta conta = null;

            //It will be needed to implement the method here


            return conta;

        }

        static Conta SolicitarDadosConta(InfoConta infoConta, List<Conta> listaContas)
        {
            int numeroAgencia;
            int numeroConta;
            Conta conta = null;

            //It will be needed to implement the method here

            return conta;
        }

        static List<Cliente> AdicionarTitular()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            //It will be needed to implement the method here

            return listaClientes;

        }

        static ContaPoupanca CriarContaPoupanca()
        {
            ContaPoupanca conta = new ContaPoupanca();

            //It will be needed to implement the method here

            return conta;
        }

        static ContaCorrente CriarContaCorrente()
        {
            ContaCorrente conta = new ContaCorrente();

            //It will be needed to implement the method here

            return conta;

        }

        static bool DepositoInicial(out double valor)
        {

            bool retorno = false;            
            valor = 0.00;

            //It will be needed to implement the method here

            return retorno;

        }

        static void Movimentar(List<Conta> listaContas)
        {
            string tipoMovimento;

            do
            {
                Write("Selecione uma movimentação que deseja realizar:");
                Write("D => Depóstio");
                Write("S => Saque");
                Write("R => Retornar ao Menu Anterior");

                tipoMovimento = Console.ReadLine();

                Conta conta = SolicitarDadosConta(InfoConta.Atual, listaContas);

                //Se não encontrar a conta volta novamente ao loop
                if (conta == null)
                    return;

                ApresentarDadosConta(conta);

                //Sai do loop se o usuário não quer mais realizar a operação
                if (tipoMovimento.ToLower() == "r")
                    break;

                switch (tipoMovimento.ToLower())
                {
                    case "d":

                        //Implement

                        break;

                    case "s":

                        //Implement

                        break;
                }

            } while (tipoMovimento.ToLower() != "r");

            ReturnText();
        }

        static void Transferir(List<Conta> listaContas)
        {
            Conta contaOrigem = SolicitarDadosConta(InfoConta.Origem, listaContas);
            Conta contaDestino = SolicitarDadosConta(InfoConta.Destino, listaContas);

            double valor = Double.Parse(WriteRead("Informe o valor que deseja transferir: "));

            if (contaOrigem == null || contaDestino == null)
                return;

            //Implement

        }

        static void ListarContas(List<Conta> listaContas)
        {
            //Implement
        }

        static void Write(string message)
        {
            Console.WriteLine(message);
        }

        static string WriteRead(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        static void ReturnText()
        {
            Console.WriteLine("Pressione uma tecla para retornar...");
            Console.ReadKey();
        }
    }
}
