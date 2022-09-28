namespace GenFin.Core.Infra.Repositories
{
    public class PaymentMethodRepository : Repository<PaymentMethod, GenFinContext>, IPaymentMethodRepository
    {
        public PaymentMethodRepository( GenFinContext context ) : base( context )
        {
        }
    }
}