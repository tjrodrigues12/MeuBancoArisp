namespace AppExercicio5.Util
{
    public enum TipoConta {

         ContaCorrente = 'C',
         ContaPoupanca = 'P'
    }

    public enum TipoOperacao
    {
        AberturaConta = 'A',
        Movimentacao = 'M',
        ListarContas = 'L',
        Transferencia = 'T',
        SairDoPrograma = 'S'
    }

    public enum InfoConta
    {
        Atual = 'A',
        Origem = 'O',
        Destino = 'D'
    }
}
