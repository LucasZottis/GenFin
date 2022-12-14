namespace GenFin.Core.Infra.ModelMappers
{
    internal class PaymentMethodModelMapper : EntityModelMapper<PaymentMethod>
    {
        public PaymentMethodModelMapper( EntityTypeBuilder<PaymentMethod> entityTypeBuilder ) : base( entityTypeBuilder )
        {
        }

        public override void Map()
        {
            Property( f => f.Name )
                .HasColumnType( SqlColumnTypes.ShortText )
                .HasMaxLength( 30 )
                .IsRequired();
        }
    }
}