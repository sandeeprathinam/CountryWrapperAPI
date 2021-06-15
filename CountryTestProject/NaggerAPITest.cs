using CountryHolidaysWrapperAPI;
using CountryHolidaysWrapperAPI.Controllers;
using CountryHolidaysWrapperAPI.Managers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NSubstitute;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace CountryTestProject
{
    public class NaggerAPITest 
    {
        private readonly HttpClient _client;
        public NaggerAPITest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://date.nager.at/api/v3/PublicHolidays/​");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        [Fact]
        public async Task TestGetCountrybyMostHolidays()
        {
            //Arrange
           var request = new
           {
               Url = "2020/AD"
           };

            //Act
           var response = await _client.GetAsync(request.Url);

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
