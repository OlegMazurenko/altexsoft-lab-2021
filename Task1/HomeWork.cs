using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    internal class HomeWork
    {
        private decimal GetFullPrice(
                                    IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    IEnumerable<decimal> prices,
                                    IEnumerable<string> currencies)
        {
            decimal fullPrice = default;

            var destinationsArray = destinations.ToArray();
            var clientsArray = clients.ToArray();
            var pricesArray = prices.ToArray();
            var currenciesArray = currencies.ToArray();
            var streetsArray = new string[destinationsArray.Length];

            if (destinationsArray.Length != clientsArray.Length ||
                destinationsArray.Length != pricesArray.Length ||
                destinationsArray.Length != currenciesArray.Length)
            {
                throw new Exception("destinations, clients, prices and currencies must have same lengths");
            }

            for (int i = 0; i < destinationsArray.Length; i++)
            {
                var destinationsArrayStreet = destinationsArray[i];
                var streetArray = destinationsArrayStreet.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var street = streetArray[0];
                var streetName = street.Split(" ").Select(x => x.Trim()).ToArray();
                streetsArray[i] = string.Join(" ", streetName.Skip(1));
            }

            for (int i = 0; i < destinationsArray.Length; i++)
            {
                if (currenciesArray[i] == "EUR")
                {
                    pricesArray[i] *= 1.19m;
                    currenciesArray[i] = "USD";
                }

                if (streetsArray[i] == "Wayne Street")
                {
                    pricesArray[i] += 10;
                }

                if (streetsArray[i] == "North Heather Street")
                {
                    pricesArray[i] -= 5.36m;
                }

                if (childrenIds.Contains(i))
                {
                    pricesArray[i] *= 0.75m;
                }

                if (infantsIds.Contains(i))
                {
                    pricesArray[i] *= 0.5m;
                }

                if (i > 0)
                {
                    if (streetsArray[i] == streetsArray[i - 1])
                    {
                        pricesArray[i] *= 0.85m;
                    }
                }

                fullPrice += pricesArray[i];
            }

            return fullPrice;
        }

        public decimal InvokePriceCalculatiion()
        {
            var destinations = new[]
            {
                "949 Fairfield Court, Madison Heights, MI 48071",
                "367 Wayne Street, Hendersonville, NC 28792",
                "910 North Heather Street, Cocoa, FL 32927",
                "911 North Heather Street, Cocoa, FL 32927",
                "706 Tarkiln Hill Ave, Middleburg, FL 32068",
            };

            var clients = new[]
            {
                "Autumn Baldwin",
                "Jorge Hoffman",
                "Amiah Simmons",
                "Sariah Bennett",
                "Xavier Bowers",
            };

            var infantsIds = new[] { 2 };
            var childrenIds = new[] { 3, 4 };

            var prices = new[] { 100, 25.23m, 58, 23.12m, 125 };
            var currencies = new[] { "USD", "USD", "EUR", "USD", "USD" };

            return GetFullPrice(destinations, clients, infantsIds, childrenIds, prices, currencies);
        }
    }
}
