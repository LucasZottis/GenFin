namespace GenFin.Core.Infra.ModelMappers
{
    internal class CostCenterModelMapper : EntityModelMapper<CostCenter>
    {
        public CostCenterModelMapper( EntityTypeBuilder<CostCenter> entityTypeBuilder ) : base( entityTypeBuilder )
        {
        }

        public override void Map()
        {
            Property( c => c.Name )
                .HasColumnType( "varchar" )
                .HasMaxLength( 20 )
                .IsRequired();
        }
    }
}
