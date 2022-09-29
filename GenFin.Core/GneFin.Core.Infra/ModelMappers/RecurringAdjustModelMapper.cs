namespace GenFin.Core.Infra.ModelMappers
{
    internal class RecurringAdjustModelMapper : EntityModelMapper<RecurringAdjust>
    {
        public RecurringAdjustModelMapper( EntityTypeBuilder<RecurringAdjust> entityTypeBuilder ) : base( entityTypeBuilder )
        {
        }

        public override void Map()
        {
            EntityTypeBuilder.HasOne( r => r.RecurringTransaction )
                .WithMany( r => r.Adjusts )
                .HasForeignKey( r => r.IdRecurringTransaction );

            Property( p => p.DateStart )
                .HasColumnType( SqlColumnTypes.Date )
                .IsRequired();

            Property( p => p.Percent )
                .HasColumnType( SqlColumnTypes.LongPercentage )
                .IsRequired();
        }
    }
}