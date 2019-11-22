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
            Write($"Tipo de Conta: {Enum.GetName(conta.RetornarTipoConta.GetType(), conta.RetornarTipoConta)}");
            Write($"Numero da agência: {conta.NumeroAgencia}");
            Write($"Numero da Conta: {conta.NumeroConta}");

            Write("Titulare(s): ");
            ListarTitulares(conta.Titulares);
        }

        static Conta AberturaDeConta()
        {

            TipoConta tipoConta;
            Conta conta = null;

            tipoConta = (TipoConta)Convert.ToChar(WriteRead("Informe o tipo de conta que deseja abrir: C => Conta Corrente / P => Poupança ").ToUpper());

            switch (tipoConta)
            {
                case TipoConta.ContaCorrente:
                    conta = new ContaCorrente();
                    break;

                case TipoConta.ContaPoupanca:
                    conta = new ContaPoupanca();
                    break;
            }

            conta.NumeroAgencia = Convert.ToInt32(WriteRead("Informe o número da agência: "));
            conta.NumeroConta = Banco.NovoNumeroConta();
            conta.Titulares = AdicionarTitular();
            conta.Depositar(DepositoInicial());

            ReturnText();

            return conta;

        }

        static Conta SolicitarDadosConta(InfoConta infoConta, List<Conta> listaContas)
        {

            Write($"Informe os dados da conta {Enum.GetName(infoConta.GetType(), infoConta)}: ");

            int numeroAgencia = Convert.ToInt32(WriteRead("Informe o numero da agência: "));
            int numeroConta = Convert.ToInt32(WriteRead("Informe o número da Conta "));

            Conta conta = listaContas.FirstOrDefault(c => c.NumeroAgencia == numeroAgencia
                          && c.NumeroConta == numeroConta);

            return conta;
        }

        static List<Cliente> AdicionarTitular()
        {            
            var numTitular = 1;
            var listaClientes = new List<Cliente>();


            do
            {
                var cliente = new Cliente();
                
                cliente.CPF = WriteRead($"Informe o CPF do {numTitular}° Titular: ");
                cliente.Nome = WriteRead($"Informe o {numTitular}° Nome do Titular: ");

                listaClientes.Add(cliente);

                if(WriteRead("Deseja adicionar mais um Titular? S=> Sim / N=> Não").ToLower() == "n")
                {
                    break;
                }

                numTitular++;

            } while (true);


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

        static double DepositoInicial()
        {
            var valor = 0.00;
            
            if(WriteRead("Deseja realizar um depósito inicial? S=> sim  / N=> não: ").ToLower() == "s")
            {
                valor = Convert.ToDouble(WriteRead("Informe o valor inicial de depósito: "));         
            }

            return valor;

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

                var valor = 0.00;
                switch (tipoMovimento.ToLower())
                {
                    case "d":

                        valor = Convert.ToDouble(WriteRead("Informe o valor de deposito: "));
                        conta.Depositar(valor);
                        
                        break;

                    case "s":

                        valor = Convert.ToDouble(WriteRead("Informe o valor que deseja sacar: "));
                        conta.Sacar(valor);

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

            contaOrigem.Sacar(valor);
            contaDestino.Depositar(valor);

            ReturnText();

        }

        static void ListarContas(List<Conta> listaContas)
        {
            Write("Lista de contas: ");
            foreach (var item in listaContas)
            {
                ApresentarDadosConta(item);
            }

            Write("-----------------------------------------");

            ReturnText();

        }

        static void ListarTitulares(List<Cliente> listaClientes)
        {
            var numTitular = 1;
            foreach (var item in listaClientes)
            {
                Write($"Nome do {numTitular}º Titular: {item.Nome}");
                Write($"CPF do {numTitular}º Titular: {item.CPF}");

                numTitular++;
            }
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
            Write("Operação realizada com sucesso!");
            Write("Pressione uma tecla para retornar...");
            Console.ReadKey();
        }
    }
}
