using ShipIt.PriceQuote.Api.Contracts.DTO;
using ShipIt.PriceQuote.Api.Services;
using System.Text.Json.Serialization;

namespace ShipIt.PriceQuote.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers().AddJsonOptions(opt => {
                opt.JsonSerializerOptions.Converters.Add(
                    new JsonStringEnumConverter());
            });

            // Add services to the container

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            /*
            var quoteService = new PriceQuoteService(basePrice: 2.5, cm3Price: 0.0001, kgPrice: 1.15, crossCountryPrice: 3.0);
            builder.Services.AddSingleton<IPriceQuoteService>(quoteService);
            */

            builder.Services.AddScoped<IPriceQuoteService>(s => new PriceQuoteService(basePrice: 2.5, cm3Price: 0.0001, kgPrice: 1.15, crossCountryPrice: 3.0));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error-development");
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.MapControllers();

            // app.UseHttpsRedirection();

            app.Run();
        }
    }
}
