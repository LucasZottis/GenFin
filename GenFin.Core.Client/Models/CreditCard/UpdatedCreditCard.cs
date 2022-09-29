namespace GenFin.Core.Client.Models.CreditCard
{
    public class UpdatedCreditCard
    {
        public int Id { get; set; }
        public byte BestDayToBuy { get; set; }
        public byte DueDate { get; set; }
        public decimal CreditLimit { get; set; }
    }
}