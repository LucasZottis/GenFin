using GenFin.Core.Dominio;
using GenFin.Core.Infra;
using GenFin.Core.Infra.Builders;
using GenFin.Core.Infra.Interfaces;
using GenFin.Core.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GenFin.Core.Aplicacao.Extensions
{
    public static class ServiceCollectionExtensoes
    {
        private static IServiceCollection InjectMapper( this IServiceCollection services )
            => services.AddSingleton( MapperBuilder.BuildMapper() );

        private static IServiceCollection InjectLogger( this IServiceCollection services )
            => services.AddSingleton( LoggerBuilder.BuildLogger() );

        private static IServiceCollection InjectRepositories( this IServiceCollection services )
        {
            return services.AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<ICostCenterRepository, CostCenterRepository>()
                .AddScoped<ICreditCardRepository, CreditCardRepository>()
                .AddScoped<IPaymentMethodRepository, PaymentMethodRepository>()
                .AddScoped<IPaymentSourceRepository, PaymentSourceRepository>()
                .AddScoped<IBillRepository, BillRepository>()
                .AddScoped<IBillItemRepository, BillItemRepository>()
                .AddScoped<IRecurringAdjustRepository, RecurringAdjustRepository>()
                .AddScoped<IRecurringTransactionRepository, RecurringTransactionRepository>()
                .AddScoped<ITransactionRepository, TransactionRepository>();
        }

        public static IServiceCollection InjectCors( this IServiceCollection services )
        {
            return services.AddCors( opcao => opcao.AddPolicy( "HabilitarOrigem", politica =>
            {
                politica.WithOrigins( @"https://localhost:7143" )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
            } ) );
        }


        public static IServiceCollection InjectContext( this IServiceCollection services )
            => services.AddDbContext<GenFinContext>( opcoes
                => opcoes.UseSqlServer( GenFinConfig.ConnectionString ), ServiceLifetime.Scoped );

        public static IServiceCollection InjectScopedServices( this IServiceCollection services )
        {
            return services.InjectRepositories();
        }

        public static IServiceCollection InjectSingletonServices( this IServiceCollection services )
        {
            return services.InjectMapper()
                .InjectLogger();
        }
    }
}