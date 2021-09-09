using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using DeliveryService.Interfaces;
using System.Globalization;
using DeliveryService.Models;
using System.Text.Json;

namespace DeliveryService.Controllers
{
    public class CurrencyController : ICurrencyController
    {
        public async Task<decimal> GetUsdRateAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
            return JsonSerializer.Deserialize<List<Currency>>(response).First(x => x.CurrencyCode == "USD").Rate;
        }
    }
}
