namespace GenFin.Core.Infra.ModelMappers
{
    internal class PaymentSourceModelMapper : EntityModelMapper<PaymentSource>
    {
        public PaymentSourceModelMapper( EntityTypeBuilder<PaymentSource> entityTypeBuilder ) : base( entityTypeBuilder )
        {
        }

        public override void Map()
        {
            Property( c => c.IncludeInBalance )
                .IsRequired();
        }
    }
}