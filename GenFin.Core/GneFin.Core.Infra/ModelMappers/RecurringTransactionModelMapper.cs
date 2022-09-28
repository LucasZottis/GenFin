namespace GenFin.Core.Infra.ModelMappers
{
    internal class RecurringTransactionModelMapper : EntityModelMapper<RecurringTransaction>
    {
        public RecurringTransactionModelMapper( EntityTypeBuilder<RecurringTransaction> entityTypeBuilder ) : base( entityTypeBuilder )
        {
        }

        public override void Map()
        {
            EntityTypeBuilder.HasOne( p => p.PaymentMethod )
                .WithMany( p => p.RecurringTransactions )
                .HasForeignKey( p => p.IdPaymentMethod );

            EntityTypeBuilder.HasOne( p => p.CostCenter )
                .WithMany( p => p.RecurringTransactions )
                .HasForeignKey( p => p.IdCostCenter );

            EntityTypeBuilder.HasOne( p => p.Category )
                .WithMany( p => p.RecurringTransactions )
                .HasForeignKey( p => p.IdCategory );

            Property( p => p.DateStart )
                .IsRequired();

            Property( p => p.Value )
                .HasColumnType( "money" )
                .IsRequired();

            Property( p => p.Kind )
                .IsRequired();

            Property( p => p.DateStart )
                .HasColumnType( "varchar" )
                .HasMaxLength( 150 )
                .IsRequired();

            Property( p => p.Frequency )
                .IsRequired();
        }
    }
}