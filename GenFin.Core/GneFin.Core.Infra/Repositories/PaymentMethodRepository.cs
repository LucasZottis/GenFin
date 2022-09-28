namespace GenFin.Core.Infra.Repositories
{
    public class PaymentMethodRepository : Repository<PaymentMethod, GenFinContexto>, IPaymentMethodRepository
    {
        public PaymentMethodRepository( GenFinContexto context ) : base( context )
        {
        }
    }
}