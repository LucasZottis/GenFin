using BibliotecaPublica.Extensoes.Extensoes;
using BibliotecaPublica.NegocioPack.Interfaces;

namespace GenFin.Api
{
    public class Controller : ControllerBase
    {
        private readonly NLog.ILogger _logger;
        private readonly INegocio _negocio;

        public Controller( NLog.ILogger logger, INegocio negocio )
        {
            _logger = logger;
            _negocio = negocio;
        }

        protected ObjectResult InternalServerError( Exception ex )
        {
            _logger.Error( ex );
            return StatusCode( 500, ex.ToString() );
        }

        protected ActionResult ReturnInvalidations( string invalidacoes )
        {
            return ValidationProblem( null, null, 400, "Ocorreu uma ou mais invalidações.", invalidacoes );
        }

        protected ActionResult<TipoRetorno> ValidateReturn<TipoRetorno>( TipoRetorno retorno )
        {
            if ( retorno == null )
                return ReturnInvalidations( _negocio.RetornarNotificacoes() );

            return Ok( retorno );
        }

        protected ActionResult ValidateReturn( Action action, string completionMessage )
        {
            var notifications = _negocio.RetornarNotificacoes();

            if ( notifications.TemConteudo() )
                return ReturnInvalidations( _negocio.RetornarNotificacoes() );
            "Concluded"
            return Ok( completionMessage );
        }

        protected ActionResult ValidateReturn( Action action )
            => ValidateReturn( action, "Concluded" );
    }
}