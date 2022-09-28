using GenFin.Core.Dominio;
using GenFin.Core.Infra;
using GenFin.Core.Infra.Interfaces;
using GenFin.Core.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GenFin.Core.Aplicacao.Extensions
{
    public static class ServiceCollectionExtensoes
    {
        private static IServiceCollection InjetarRepositorios( this IServiceCollection servicos )
        {
            return servicos.AddScoped<ICategoryRepository, CategoryRepository>()
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

        public static void InjetarContexto( this IServiceCollection servicos )
        {
            servicos.AddDbContext<GenFinContexto>( opcoes => opcoes.UseSqlServer( GenFinConfig.ConnectionString ), ServiceLifetime.Scoped );
        }

        public static IServiceCollection InjetarServicosScoped( this IServiceCollection servicos )
        {
            return servicos.InjetarRepositorios();
        }
    }
}