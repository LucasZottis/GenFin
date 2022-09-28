using GenFin.Core.Dominio.Enums;

namespace GenFin.Core.Infra.ModelMappers
{
    internal class BillItemModelMapper : EntityModelMapper<BillItem>
    {
        public BillItemModelMapper( EntityTypeBuilder<BillItem> entityTypeBuilder ) : base( entityTypeBuilder )
        {
        }

        public override void Map()
        {
            EntityTypeBuilder.HasOne( b => b.CostCenter )
                .WithMany( c => c.BillItems )
                .HasForeignKey( b => b.IdCostCenter );

            EntityTypeBuilder.HasOne( b => b.Category )
                .WithMany( c => c.BillItems )
                .HasForeignKey( b => b.IdCategory );

            EntityTypeBuilder.HasOne( b => b.Bill )
                .WithMany( c => c.BillItems )
                .HasForeignKey( b => b.IdBill );

            Property( b => b.PurchaseDate )
                .IsRequired();

            Property( b => b.Value )
                .HasColumnType( "money" )
                .IsRequired();

            Property( b => b.Description )
                .HasColumnType( "varchar" )
                .HasMaxLength( 50 )
                .IsRequired();

            Property( b => b.Establishment )
                .HasColumnType( "varchar" )
                .HasMaxLength( 30 )
                .IsRequired();

            Property( b => b.Installment )
                .IsRequired();

            Property( b => b.TotalInstallment )
                .IsRequired();

            Property( b => b.Kind )
                .HasDefaultValue( TransactionKind.Expense )
                .IsRequired();
        }
    }
}