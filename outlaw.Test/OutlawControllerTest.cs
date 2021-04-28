using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace outlaw.Test
{
    public class OutlawControllerTest : IClassFixture<WebApplicationFactory<outlawapi.Startup>>
    {
        public HttpClient Client { get; set; }
        [Fact]
        public void Get_DeathCauses_Should_Return_Ok()
        {
            
        }
    }
}
