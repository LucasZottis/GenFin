namespace GenFin.Core.Client.Models.CreditCard
{
    public class SimplifiedCreditCard : Entity
    {
        public byte BestDayToBuy { get; set; }
        public byte DueDate { get; set; }
        public decimal CreditLimit { get; set; }
    }
}