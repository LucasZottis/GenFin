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
                .HasColumnType( SqlColumnTypes.Date )
                .IsRequired();

            Property( p => p.Value )
                .HasColumnType( SqlColumnTypes.Money )
                .IsRequired();

            Property( p => p.Status )
                .IsRequired();

            Property( p => p.Kind )
                .IsRequired();

            Property( p => p.Description )
                .HasColumnType( SqlColumnTypes.ShortText )
                .HasMaxLength( 150 )
                .IsRequired();

            Property( p => p.Establishment )
                .HasColumnType( SqlColumnTypes.ShortText )
                .HasMaxLength( 50 )
                .IsRequired();

            Property( p => p.Frequency )
                .IsRequired();
        }
    }
}