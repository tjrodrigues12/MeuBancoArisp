using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExercicio4
{
    public class Conta
    {
        #region | Fields |
        public string NomeDoBanco = "Banco .NET";        
        #endregion

        #region | Properties |
        public int Agencia { get; set; }
        public int NumeroConta { get; set; }
        public string NomeDoTitular { get; set; }
        public char TipoConta { get; set; }
        public double Saldo { get; private set; }
        #endregion

        #region | Constructors |
        public Conta()
        {

        }        
        #endregion

        #region | Methods |
        public void Despositar(double valor)
        {
            this.Saldo += valor;
        }

        public bool Sacar(double valor)
        {
            var retorno = PodeSacar(valor);
            this.Saldo -= retorno ? valor : 0;
            return retorno;
        }        

        private bool PodeSacar(double valor)
        {
            return Saldo >= valor;
        }

        public void AbrirConta(int agencia, int numeroConta, string nomeDoTitular, char tipoConta)
        {
            this.Agencia = agencia;
            this.NumeroConta = numeroConta;
            this.NomeDoTitular = NomeDoTitular;
            this.TipoConta = tipoConta;
            this.Saldo = Saldo;
        }
        
        #endregion

    }
}
