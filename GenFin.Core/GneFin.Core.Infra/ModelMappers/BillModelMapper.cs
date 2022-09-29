namespace GenFin.Core.Infra.ModelMappers
{
    internal class BillModelMapper : EntityModelMapper<Bill>
    {
        public BillModelMapper( EntityTypeBuilder<Bill> entityTypeBuilder ) : base( entityTypeBuilder )
        {
        }

        public override void Map()
        {
            EntityTypeBuilder.HasOne( b => b.CreditCard )
                .WithMany( c => c.Bills )
                .HasForeignKey( b => b.IdCreditCard );

            EntityTypeBuilder.HasOne( b => b.PaymentSource )
                .WithMany( c => c.PaidBills )
                .HasForeignKey( b => b.IdPaymentSource );

            Property( b => b.BillDueDate )
                .HasColumnType( SqlColumnTypes.Date )
                .IsRequired();

            Property( b => b.PaidValue )
                .HasColumnType( SqlColumnTypes.Money )
                .IsRequired();

            Property( b => b.PaymentStatus )
                .HasDefaultValue( PaymentStatus.Payable )
                .IsRequired();
        }
    }
}