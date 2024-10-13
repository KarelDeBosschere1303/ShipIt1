using ShipIt.PriceQuote.Api.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShipIt.PriceQuote.Api.Contracts.DTO
{
    public class PriceQuoteRequestContract
    {
        [Required]
        [Range(1,100)]
        public int? LengthCm { get; set; }
        [Required]
        [Range(1, 100)]
        public int? WidthCm { get; set; }
        [Required]
        [Range(1, 100)]
        public int? HeightCm { get; set; }
        [Required]
        [Range(1, 10)]
        public double? WeightKg { get; set; }
        [Required]
        public CountryEnum? CountryFrom { get; set; }
        [Required]
        public CountryEnum? CountryTo { get; set; }
    }
}
