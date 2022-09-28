using Microsoft.Extensions.Configuration;

namespace GenFin.Core.Dominio
{
    public static class GenFinConfig
    {
        public static string ConnectionString { get; private set; }

        public static void Configurar( this IConfiguration configuracoes )
        {
            ConnectionString = configuracoes.GetConnectionString( "GenFinDb" );
        }
    }
}