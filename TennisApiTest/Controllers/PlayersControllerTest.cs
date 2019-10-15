using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using TennisApi;
using TennisApi.Business;
using TennisApi.Models;
using Xunit;

namespace TennisApiTest.Controllers
{
   public class PlayersControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        public PlayersControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services => { services.AddScoped<IPlayerBusiness, PlayerBusinessMock>(); });
            }).CreateClient();
        }

        private readonly HttpClient _client;


        private readonly WebApplicationFactory<Startup> _factory;

        [Fact]
        public async void TestGetPlayers_Should_ReturnPlayers()
        {
            // When
            var message = new HttpRequestMessage(HttpMethod.Get, "/api/players");
            var httpResponseMessage = await _client.SendAsync(message);

            // Then
            var httpBody = await httpResponseMessage.Content.ReadAsStringAsync();

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            httpResponseMessage.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");

            var result = JArray.Parse(httpBody);
            result.Count.Should().Be(2);
            result[0]["firstName"].Value<string>().Should().Be("Roger");
            result[0]["lastName"].Value<string>().Should().Be("Federer");
            result[0]["id"].Value<int>().Should().Be(1);
            result[0]["shortName"].Value<string>().Should().Be("Roger");
            result[0]["sex"].Value<string>().Should().Be("M");
            result[0]["country"]["code"].Value<string>().Should().Be("ch");
            result[0]["country"]["picture"].Value<string>().Should().Be("suisse.png");
            result[0]["data"]["rank"].Value<int>().Should().Be(3);
            result[0]["data"]["points"].Value<int>().Should().Be(500);
            result[0]["data"]["weights"].Value<int>().Should().Be(80);
            result[0]["data"]["height"].Value<int>().Should().Be(185);
            result[0]["data"]["age"].Value<int>().Should().Be(84);
            result[0]["data"]["last"].Value<JArray>().Count.Should().Be(5);
        }

        [Fact]
        public async void TestGetPlayer_WhenPlayerExist_Should_ReturnData()
        {
            // When
            var message = new HttpRequestMessage(HttpMethod.Get, "/api/players/1");
            var httpResponseMessage = await _client.SendAsync(message);

            // Then
            var httpBody = await httpResponseMessage.Content.ReadAsStringAsync();

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            httpResponseMessage.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");

            var result = JObject.Parse(httpBody);
            result["firstName"].Value<string>().Should().Be("Roger");
            result["lastName"].Value<string>().Should().Be("Federer");
            result["id"].Value<int>().Should().Be(1);
            result["shortName"].Value<string>().Should().Be("Roger");
            result["sex"].Value<string>().Should().Be("M");
            result["country"]["code"].Value<string>().Should().Be("ch");
            result["country"]["picture"].Value<string>().Should().Be("suisse.png");
            result["data"]["rank"].Value<int>().Should().Be(3);
            result["data"]["points"].Value<int>().Should().Be(500);
            result["data"]["weights"].Value<int>().Should().Be(80);
            result["data"]["height"].Value<int>().Should().Be(185);
            result["data"]["age"].Value<int>().Should().Be(84);
            result["data"]["last"].Value<JArray>().Count.Should().Be(5);
        }

        [Fact]
        public async void TestGetPlayer_WhenPlayerNotExist_Should_ReturnNotFound()
        {
            // When
            var message = new HttpRequestMessage(HttpMethod.Get, "/api/players/88");
            var httpResponseMessage = await _client.SendAsync(message);

            // Then
            var httpBody = await httpResponseMessage.Content.ReadAsStringAsync();

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.NotFound);   
        }

        [Fact]
        public async void TestDeletePlayer_WhenPlayerExist_Should_ReturnNoContent()
        {
            // When
            var message = new HttpRequestMessage(HttpMethod.Delete, "/api/players/1");
            var httpResponseMessage = await _client.SendAsync(message);

            // Then
            var httpBody = await httpResponseMessage.Content.ReadAsStringAsync();

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async void TestDeletePlayer_WhenPlayerNotExist_Should_ReturnNoContent()
        {
            // When
            var message = new HttpRequestMessage(HttpMethod.Delete, "/api/players/671");
            var httpResponseMessage = await _client.SendAsync(message);

            // Then
            var httpBody = await httpResponseMessage.Content.ReadAsStringAsync();

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
