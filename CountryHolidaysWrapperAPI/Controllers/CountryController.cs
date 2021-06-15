using CountryHolidaysWrapperAPI.Managers;
using CountryHolidaysWrapperAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryHolidaysWrapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryManager _countryMananger;
        public CountryController(ICountryManager countryMananger)
        {
            _countryMananger = countryMananger;
        }
        [HttpGet]
        [Route("GetHolidayAsyncforAllCountries/{Year}")]
        public async Task<ActionResult<List<Holiday>>> GetHolidayAsyncforAllCountries(string Year)
        {
            try
            {
                var holidays = await _countryMananger.GetHolidayAsyncforAllCountries(Year);
                return new OkObjectResult(holidays);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet]
        [Route("GetCountrybyMostHolidays/{Year}")]
        public async Task<ActionResult<List<Holiday>>> GetCountrybyMostHolidays(string Year)
        {
            try
            {
                var holidays = await _countryMananger.GetCountrybyMostHolidays(Year);
                return new OkObjectResult(holidays);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet]
        [Route("GetMonthbyMostHolidays/{Year}")]
        public async Task<ActionResult<List<Holiday>>> GetMonthbyMostHolidays(string Year)
        {
            try
            {
                var holidays = await _countryMananger.GetMonthbyMostHolidays(Year);
                return new OkObjectResult(holidays);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet]
        [Route("GetUniqueHolidays/{Year}")]
        public async Task<ActionResult<List<Holiday>>> GetUniqueHolidays(string Year)
        {
            try
            {
                var holidays = await _countryMananger.GetUniqueHolidays(Year);
                return new OkObjectResult(holidays);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
