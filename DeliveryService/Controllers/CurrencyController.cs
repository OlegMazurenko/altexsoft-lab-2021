using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using DeliveryService.Interfaces;

namespace DeliveryService.Controllers
{
    public class CurrencyController : ICurrencyController
    {
        public async Task<decimal> ConvertToUsdAsync(decimal price)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://bank.gov.ua/NBUStatService/v1/statdirectory/dollar_info?json");
            var rate = response
                .Split(new string[] { "\"rate\":" }, StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0];
            decimal.TryParse(rate.Replace('.', ','), out var parsedRate);
            return price / parsedRate;
        }
    }
}
