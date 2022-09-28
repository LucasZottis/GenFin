namespace GenFin.Core.Infra.Repositories
{
    public class PaymentSourceRepository : Repository<PaymentSource, GenFinContext>, IPaymentSourceRepository
    {
        public PaymentSourceRepository( GenFinContext context ) : base( context )
        {
        }
    }
}