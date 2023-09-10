using NetCore_TraversalApp.Areas.Admin.Controllers;
using Newtonsoft.Json;

namespace NetCore_TraversalApp.Areas.Admin.Models
{
    public class BookingCurrencyRateViewModel
    {
        [JsonProperty("base_currency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("base_currency_date")]
        public DateTime BaseCurrencyDate { get; set; }

        [JsonProperty("exchange_rates")]
        public List<ExchangeRate> Rates { get; set; }
    }


    public class ExchangeRate
    {
        [JsonProperty("exchange_rate_buy")]
        public double Rate { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

    }
}
