using System.Collections.Generic;

using AppExercicio5.Interface;
using AppExercicio5.Util;

namespace AppExercicio5.Domain
{
    public abstract class Conta : IConta
    {
        #region | Fields |
        protected readonly double taxaRendimento = 0.037;
        #endregion

        #region| Properties |
        public int NumeroAgencia { get; set; }
        public int NumeroConta { get; set; }
        protected double Saldo { get; set; }
        public List<Cliente> Titulares { get; set; }
        public abstract TipoConta RetornarTipoConta { get; }
        #endregion

        #region | Methods |
        protected string EmitirExtrato()
        {
            return "Extrato";            
        }       

        protected virtual void RenderSaldo()
        {
            Saldo = 1.00;
        }

        public virtual bool Sacar(double valor)
        {
            bool retorno = false;

            if (this.Saldo >= valor)
            {
                this.Saldo -= valor;
                retorno = true;
            }

            return retorno;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }

        #endregion
    }
}
