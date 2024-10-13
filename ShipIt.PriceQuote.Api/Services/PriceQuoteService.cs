using ShipIt.PriceQuote.Api.Contracts.DTO;

namespace ShipIt.PriceQuote.Api.Services
{
    public class PriceQuoteService : IPriceQuoteService
    {
        private readonly double _basePrice;
        private readonly double _cm3Price;
        private readonly double _kgPrice;
        private readonly double _crossCountryPrice;

        public PriceQuoteService(double basePrice, double cm3Price, double kgPrice, double crossCountryPrice) 
        { 
            _basePrice = basePrice;
            _cm3Price = cm3Price;
            _kgPrice = kgPrice;
            _crossCountryPrice = crossCountryPrice;
        }

        public PriceQuoteResponseContract CreatePriceQuote(PriceQuoteRequestContract quoteRequest)
        {           
            var volumeCm3 = quoteRequest.LengthCm * quoteRequest.HeightCm * quoteRequest.WidthCm;

            var price = _basePrice + volumeCm3 * _cm3Price + quoteRequest.WeightKg * _kgPrice;

            if (quoteRequest.CountryFrom != quoteRequest.CountryTo)
                price += _crossCountryPrice;

            var priceRounded = Math.Round(price.Value, 1);

            var response = new PriceQuoteResponseContract
            {
                Quote = priceRounded,
                ValidUntil = DateTime.UtcNow.AddHours(48)
            };

            return response;

        }
    }
}
