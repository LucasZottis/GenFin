using GenFin.Core.Infra.Interfaces;

namespace GenFin.Core.Infra.Repositories
{
    public class CreditCardRepository : Repository<CreditCard, GenFinContext>, ICreditCardRepository
    {
        public CreditCardRepository( GenFinContext context ) : base( context )
        {
        }
    }
}