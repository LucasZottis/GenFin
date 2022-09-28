namespace GenFin.Core.Infra.ModelMappers
{
    internal class CreditCardModelMapper : EntityModelMapper<CreditCard>
    {
        public CreditCardModelMapper( EntityTypeBuilder<CreditCard> entityTypeBuilder ) : base( entityTypeBuilder )
        {

        }

        public override void Map()
        {
            Property( e => e.BestDayToBuy )
                .HasDefaultValue( 1 )
                .IsRequired();

            Property( e => e.DueDate )
                .HasDefaultValue( 1 )
                .IsRequired();

            Property( e => e.CreditLimit )
                .HasColumnType( "money" )
                .IsRequired();
        }
    }
}