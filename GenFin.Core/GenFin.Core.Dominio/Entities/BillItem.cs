namespace GenFin.Core.Dominio.Entities
{
    [NickName( "Item da fatura" )]
    public class BillItem : Entity
    {
        public int IdCostCenter { get; set; }
        public int IdCategory { get; set; }
        public int IdBill { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Value { get; set; }
        [NickName( "Descrição do item de fatura" )]
        public string Description { get; set; }
        [NickName( "Estabelecimento" )]
        public string Establishment { get; set; }
        public int Installment { get; set; }
        public int TotalInstallment { get; set; }
        public TransactionKind Kind { get; set; }

        public Category Category { get; set; }
        public CostCenter CostCenter { get; set; }
        public Bill Bill { get; set; }
    }
}