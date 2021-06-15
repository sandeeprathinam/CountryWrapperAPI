using CountryHolidaysWrapperAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountryHolidaysWrapperAPI.Managers
{
    public class CountryManager: ICountryManager
    {
        private readonly IHttpClientFactory _clientFactory;

        public CountryManager(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Holiday>> GetHolidayAsync(string path)
        {
            var client = _clientFactory.CreateClient("Nager");

            List<Holiday> holidays = null; 
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                holidays = JsonConvert.DeserializeObject<List<Holiday>>(responseBody);
            }
            return holidays;
        }

        public async Task<List<Holiday>> GetHolidayAsyncforAllCountries(string year)
        {
            List<Holiday> holidays =new  List<Holiday>();
            string uri = year+ "/";
            foreach(var item in CountryList.Countries)
            {
                holidays.AddRange(await GetHolidayAsync(uri+ item));
            }
            return holidays;
        }

        public async Task<string> GetCountrybyMostHolidays(string year)
        {
            List<Holiday> holidays = await GetHolidayAsyncforAllCountries(year);
            var query = holidays.GroupBy(x => x.countryCode)
                      .OrderByDescending(x => x.Count())
                                    .First();
            return query.Key;
        }
        public async Task<string> GetMonthbyMostHolidays(string year)
        {
            List<Holiday> holidays = await GetHolidayAsyncforAllCountries(year);
            var query = holidays.GroupBy(x => x.date.Month)
                      .OrderByDescending(x => x.Count())
                                    .First();
           return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(query.Key);
        }

        public async Task<string> GetUniqueHolidays(string year)
        {
            List<Holiday> holidays = await GetHolidayAsyncforAllCountries(year);                                
            var query = holidays.GroupBy(x => new { x.date.Month, x.date.Day,x.countryCode })
                     .Where(x => x.Count() == 1).Select(grp => new { grp.Key.countryCode }).GroupBy(x=> new {x.countryCode}).OrderByDescending(x => x.Count())
                                    .Last();
            return query.Key.ToString();
        }
    }
}
