using GenFin.Core.Infra.ModelMappers;

namespace GenFin.Core.Infra
{
    public class GenFinContext : DbContext
    {
        internal DbSet<PaymentMethod> PaymentMethods { get; set; }
        internal DbSet<CreditCard> CreditCards { get; set; }
        internal DbSet<PaymentSource> PaymentSources { get; set; }
        internal DbSet<Category> Categories { get; set; }
        internal DbSet<CostCenter> CostCenters { get; set; }

        public GenFinContext( DbContextOptions options ) : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            EntityModelMapperBuilder.Map<BillItemModelMapper, BillItem>( modelBuilder.Entity<BillItem>() );
            EntityModelMapperBuilder.Map<BillModelMapper, Bill>( modelBuilder.Entity<Bill>() );
            EntityModelMapperBuilder.Map<CategoryModelMapper, Category>( modelBuilder.Entity<Category>() );
            EntityModelMapperBuilder.Map<CostCenterModelMapper, CostCenter>( modelBuilder.Entity<CostCenter>() );
            EntityModelMapperBuilder.Map<CreditCardModelMapper, CreditCard>( modelBuilder.Entity<CreditCard>() );
            EntityModelMapperBuilder.Map<PaymentMethodModelMapper, PaymentMethod>( modelBuilder.Entity<PaymentMethod>() );
            EntityModelMapperBuilder.Map<PaymentSourceModelMapper, PaymentSource>( modelBuilder.Entity<PaymentSource>() );
            EntityModelMapperBuilder.Map<RecurringAdjustModelMapper, RecurringAdjust>( modelBuilder.Entity<RecurringAdjust>() );
            EntityModelMapperBuilder.Map<RecurringTransactionModelMapper, RecurringTransaction>( modelBuilder.Entity<RecurringTransaction>() );
            EntityModelMapperBuilder.Map<TransactionModelMapper, Transaction>( modelBuilder.Entity<Transaction>() );

            base.OnModelCreating( modelBuilder );
        }
    }
}