using CountryHolidaysWrapperAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryHolidaysWrapperAPI.Managers
{
    public interface ICountryManager
    {
        Task<List<Holiday>> GetHolidayAsyncforAllCountries(string year);
        Task<string> GetCountrybyMostHolidays(string year);
        Task<string> GetUniqueHolidays(string year);
        Task<string> GetMonthbyMostHolidays(string year);
    }
}
