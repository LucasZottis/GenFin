namespace GenFin.Core.Infra.ModelMappers
{
    internal class TransactionModelMapper : EntityModelMapper<Transaction>
    {
        public TransactionModelMapper( EntityTypeBuilder<Transaction> entityTypeBuilder ) : base( entityTypeBuilder )
        {
        }

        public override void Map()
        {
            EntityTypeBuilder.HasOne( p => p.PaymentSource )
                .WithMany( p => p.Transactions )
                .HasForeignKey( p => p.IdPaymentSource );

            EntityTypeBuilder.HasOne( p => p.CostCenter )
                .WithMany( p => p.Transactions )
                .HasForeignKey( p => p.IdCostCenter );

            EntityTypeBuilder.HasOne( p => p.Category )
                .WithMany( p => p.Transactions )
                .HasForeignKey( p => p.IdCategory );

            Property( p => p.Value )
                .HasColumnType( SqlColumnTypes.Money )
                .IsRequired();

            Property( p => p.PaymentStatus )
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

            Property( p => p.Installment )
                .IsRequired();

            Property( p => p.TotalInstallment )
                .IsRequired();
        }
    }
}