namespace GenFin.Core.Infra.Repositories
{
    public class PaymentSourceRepository : Repository<PaymentSource, GenFinContexto>, IPaymentSourceRepository
    {
        public PaymentSourceRepository( GenFinContexto context ) : base( context )
        {
        }
    }
}