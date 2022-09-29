using GenFin.Core.Client.Models.CreditCard;

namespace GenFin.Core.Aplicacao.Interfaces
{
    public interface ICreditCardBusinessService : INegocio
    {
        SimplifiedCreditCard? RegisterCreditCard( NewCreditCard creditCard );
        SimplifiedCreditCard? UpdateCreditCard( UpdatedCreditCard creditCard );
        void DisableCreditCard( int creditCardId );

        IEnumerable<SimplifiedCreditCard> GetCreditCards();

        internal bool IsNewCreditCardValid( NewCreditCard creditCard );
        internal bool IsUpdatedCreditCardValid( UpdatedCreditCard creditCard );
    }
}