using System.Collections.Generic;

using AppExercicio5.Util;

namespace AppExercicio5.Domain
{
    public class ContaPoupanca : Conta
    {
        #region | Properties |
        public override TipoConta RetornarTipoConta => TipoConta.ContaPoupanca;
        #endregion

        #region Methods

        protected override void RenderSaldo()
        {        
            base.Saldo += base.Saldo * base.taxaRendimento;
        }  


        public override bool Sacar(double valor)
        {

            bool retorno = false;
            this.RenderSaldo();

            if (base.Saldo >= valor)
            {
                retorno = true;
                base.Saldo -= valor;
            }

            return retorno;
        }
        #endregion

        #region Constructor
        public ContaPoupanca()
        {
           
        }
        #endregion
    }
}
