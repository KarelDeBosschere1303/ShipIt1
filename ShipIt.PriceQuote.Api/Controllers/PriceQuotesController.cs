using Microsoft.AspNetCore.Mvc;
using ShipIt.PriceQuote.Api.Contracts.DTO;
using ShipIt.PriceQuote.Api.Services;

namespace ShipIt.PriceQuote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceQuotesController : ControllerBase
    {
        private readonly IPriceQuoteService _quoteService;

        public PriceQuotesController(IPriceQuoteService quoteService) 
        { 
            _quoteService = quoteService;
        }

        [HttpPost]
        public ActionResult<PriceQuoteResponseContract> CreatePriceQuote(PriceQuoteRequestContract quoteRequest)
        {
            var price = _quoteService.CreatePriceQuote(quoteRequest);
            return price;
        }
    }
}
