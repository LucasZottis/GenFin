using GenFin.Core.Dominio.Enums;

namespace GenFin.Core.Infra.ModelMappers
{
    internal class BillModelMapper : EntityModelMapper<Bill>
    {
        public BillModelMapper( EntityTypeBuilder<Bill> entityTypeBuilder ) : base( entityTypeBuilder )
        {
        }

        public override void Map()
        {
            Property( b => b.BillDueDate )
                .IsRequired();

            Property( b => b.PaidValue )
                .HasColumnType( "money" )
                .IsRequired();

            Property( b => b.PaymentStatus )
                .HasDefaultValue( PaymentStatus.Payable )
                .IsRequired();

            EntityTypeBuilder.HasOne( b => b.CreditCard )
                .WithMany( c => c.Bills )
                .HasForeignKey( b => b.IdCreditCard );
        }
    }
}