namespace GenFin.Core.Infra.ModelMappers
{
    internal class CategoryModelMapper : EntityModelMapper<Category>
    {
        public CategoryModelMapper( EntityTypeBuilder<Category> entityTypeBuilder ) : base( entityTypeBuilder )
        {
        }

        public override void Map()
        {
            Property( c => c.Name )
                .HasColumnType( "varchar" )
                .HasMaxLength( 20 )
                .IsRequired();

            Property( c => c.ShowInCalendar )
                .IsRequired();
        }
    }
}