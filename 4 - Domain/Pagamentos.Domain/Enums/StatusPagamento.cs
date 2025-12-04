namespace Pagamentos.Domain.Enums
{
    public enum StatusPagamento
    {
        Pendente = 0,
        Processando = 1,
        Pago = 2,
        Cancelado = 3,
        Falhou = 4
    }
}
