using ShipIt.PriceQuote.Api.Contracts.DTO;

namespace ShipIt.PriceQuote.Api.Services
{
    public interface IPriceQuoteService
    {
        PriceQuoteResponseContract CreatePriceQuote(PriceQuoteRequestContract quoteRequest);
    }
}
