using Bem.Infrastructure.Repositories;
using Bem.Infrastructure.Telemetry;
using Bem.Orders.Repository;
using Bem.Payments.Integrations.Ebanx;
using Bem.Payments.Repository;
using Bem.Payments.Services.ProcessPayment;
using Bem.Products.Integrations.Stock;
using Bem.Products.Repository;
using Bem.Services;
using Bem.Services.StockApi;
using Bem.Telemetry;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry;
using System.Reflection;
using Bem.Infrastructure.Integrations.Settings;
using Microsoft.Extensions.Configuration;
using BemPropostas.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddDbContext();
        services.AddIntegrations(configuration);
        services.UseOtlpExporter();
        services.AddServices();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProcessPaymentService, ProcessPaymentService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOrdersRepository, PropostasRepository>();
        services.AddScoped<IPaymentsRepository, PaymentsRepository>();
        services.AddScoped<IProductsRepository, ProductsRepository>();
    }

    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<BemPropostasDbContext>(options => options.UseInMemoryDatabase(nameof(BemPropostasDbContext)));
    }

    public static void AddIntegrations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<StockApiSettings>(config =>
        {
            config.Uri = configuration["StockApi:Uri"];
        });
        services.AddScoped<IStockApi, StockApi>();
        services.AddScoped<IBankApi, EbanxApi>();
    }
    public static void UseOtlpExporter(this IServiceCollection services)
    {
        var assemblyName = Assembly.GetEntryAssembly().GetName();
        var serviceName = assemblyName.Name;
        var telemetrySettings = new TelemetrySettings(serviceName, assemblyName.Version?.ToString());
        services.AddSingleton(telemetrySettings);
        services.AddSingleton<ITelemetryMeter, TelemetryMeter>();
        services.AddScoped<IBemTracerProvider, BemTracerProvider>();

        services
            .AddOpenTelemetry()
            .ConfigureResource(b => ConfigureTelemetryResource(b, telemetrySettings))
            .WithTracing(builder =>
            {
                builder
                    .AddSource(serviceName)
                    .AddHttpClientInstrumentation()
                    .AddAspNetCoreInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation()
                    .AddOtlpExporter();
            })
            .WithMetrics(builder =>
            {
                builder
                    .AddMeter(serviceName)
                    .AddRuntimeInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddAspNetCoreInstrumentation()
                    .AddOtlpExporter();
            })
            .WithLogging(builder =>
            {
                builder.AddOtlpExporter();
            });
    }

    private static void ConfigureTelemetryResource(ResourceBuilder resourceBuilder, TelemetrySettings telemetrySettings)
    {
        resourceBuilder.AddService(
            serviceName: telemetrySettings.ServiceName,
            serviceVersion: telemetrySettings.ServiceVersion,
            serviceInstanceId: Environment.MachineName);
    }
}
