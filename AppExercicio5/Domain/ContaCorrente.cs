using System.Collections.Generic;

using AppExercicio5.Util;

namespace AppExercicio5.Domain
{
    public class ContaCorrente : Conta
    {

        #region | Properties |
        public override TipoConta RetornarTipoConta => TipoConta.ContaCorrente;
        #endregion

        #region | Constructors |
        public ContaCorrente()
        {

        }        
        #endregion
    }
}
