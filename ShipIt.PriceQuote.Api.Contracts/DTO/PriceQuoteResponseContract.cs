namespace ShipIt.PriceQuote.Api.Contracts.DTO
{
    public class PriceQuoteResponseContract
    {
        public double Quote { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
