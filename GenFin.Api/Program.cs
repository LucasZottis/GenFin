using GenFin.Core.Aplicacao.Extensions;

namespace GenFin.Api
{
    public static class Program
    {
        private static WebApplicationOptions BuildWebApplicationOptions( string[] args )
        {
            return new WebApplicationOptions()
            {
                ApplicationName = "GenFin.Api",
                ContentRootPath = AppContext.BaseDirectory,
                Args = args
            };
        }

        private static WebApplicationBuilder ConfigureServicesInjection( this WebApplicationBuilder builder )
        {
            // Add services to the container.
            builder.Services.InjectContext()
                .InjectCors()
                .InjectScopedServices()
                .InjectSingletonServices();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHealthChecks();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        private static WebApplication ConfigurerSwagger( this WebApplication app )
        {
            // Configure the HTTP request pipeline.
            if ( app.Environment.IsDevelopment() )
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI( item =>
                {
                    item.SwaggerEndpoint( "/swagger/v1/swagger.json", app.Environment.ApplicationName );
                    item.InjectStylesheet( "/swagger/custom.css" );
                } );

                app.UseHsts();
            }

            return app;
        }

        private static void ConfigureWebApplication( this WebApplication app )
        {
            app.ConfigurerSwagger();
            app.MapHealthChecks( "/HealthCheck" );
            app.UseCors( "HabilitarOrigem" );
            app.UseDeveloperExceptionPage( new DeveloperExceptionPageOptions() );
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }

        private static WebApplication BuildWebApplication( WebApplicationOptions options )
        {
            var builder = WebApplication.CreateBuilder( options );

            builder.Configuration.InjectConfiguration();
            builder.Host.UseWindowsService( opcao
                => opcao.ServiceName = builder.Environment.ApplicationName + "Service" );
            builder.ConfigureServicesInjection();

            return builder.Build();
        }

        public static void Main( string[] args )
        {
            var webApplicationOption = BuildWebApplicationOptions( args );
            var app = BuildWebApplication( webApplicationOption );

            app.ConfigureWebApplication();
            app.Run();
        }
    }
}