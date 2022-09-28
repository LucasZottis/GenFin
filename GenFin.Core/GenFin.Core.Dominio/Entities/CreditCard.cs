namespace GenFin.Core.Dominio.Entities
{
    [NickName( "Cartão de crédito" )]
    public class CreditCard : PaymentMethod
    {
        public byte BestDayToBuy { get; set; }
        public byte DueDate { get; set; }
        public decimal CreditLimit { get; set; }

        public ICollection<Bill> Bills { get; set; }
    }
}