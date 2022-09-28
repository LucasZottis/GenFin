using GenFin.Core.Infra.Interfaces;

namespace GenFin.Core.Infra.Repositories
{
    public class CreditCardRepository : Repository<CreditCard, GenFinContexto>, ICreditCardRepository
    {
        public CreditCardRepository( GenFinContexto context ) : base( context )
        {
        }
    }
}