using GenFin.Core.Client.Models.CreditCard;

namespace GenFin.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class CreditCardController : Controller
    {
        private readonly ICreditCardBusinessService _creditCardBusinessService;

        public CreditCardController( NLog.ILogger logger, ICreditCardBusinessService creditCardBusinessService )
            : base( logger, creditCardBusinessService )
        {
        }

        [HttpPost( "RegisterCreditCard" )]
        public ActionResult<SimplifiedCreditCard> RegisterCreditCard( NewCreditCard creditCard )
        {
            try
            {
                return ValidateReturn( _creditCardBusinessService.RegisterCreditCard( creditCard ) );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }

        [HttpPut( "UpdateCreditCard" )]
        public ActionResult<SimplifiedCreditCard> UpdateCreditCard( UpdatedCreditCard creditCard )
        {
            try
            {
                return ValidateReturn( _creditCardBusinessService.UpdateCreditCard( creditCard ) );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }

        [HttpGet( "GetCreditCards" )]
        public ActionResult<IEnumerable<SimplifiedCreditCard>> GetCreditCards()
        {
            try
            {
                return ValidateReturn( _creditCardBusinessService.GetCreditCards() );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }

        [HttpPut( "DisableCreditCard" )]
        public ActionResult DisableCreditCard( int creditCardId )
        {
            try
            {
                return ValidateReturn( () => _creditCardBusinessService.DisableCreditCard( creditCardId ) );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }
    }
}