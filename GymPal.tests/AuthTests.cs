using Microsoft.VisualStudio.TestPlatform.TestHost;
using GymPal;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
namespace GymPal.tests
{

    public class AuthTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public AuthTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
        {
            //arrange
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync("/api/private");
            //assert
            response.EnsureSuccessStatusCode();
        }
    }
}