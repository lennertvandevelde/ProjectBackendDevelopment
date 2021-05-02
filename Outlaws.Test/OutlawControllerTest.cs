using System;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using Outlaws.API.Models;
using Outlaws.API.DTO;
using System.Text;
using System.Net.Http.Headers;
using RestSharp;

namespace outlaw.Test
{
    public class OutlawControllerTest : IClassFixture<WebApplicationFactory<Outlaws.API.Startup>>
    {
        public HttpClient Client { get; set; }
        public OutlawControllerTest(WebApplicationFactory<Outlaws.API.Startup> fixture)
        {
            Client = fixture.CreateClient();
            var client = new RestClient("https://dev-xpm56lsq.eu.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"MPOn4zJqPgcY2hP8usfmfTtbEAUBxSlR\",\"client_secret\":\"OMRGvMguKdj1Bzw1_JMNLGFn5HDDWDO5ucmqRQrz3RuO1gPocIIrl4ORHmUVwRXW\",\"audience\":\"https:/outlaw\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{values["access_token"]}");
        }
        [Fact]
        public async Task Get_DeathCauses_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/deathcauses");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var deathCauses = JsonConvert.DeserializeObject<List<DeathCause>>(await response.Content.ReadAsStringAsync());
            Assert.True(deathCauses.Count > 0);
        }
        [Fact]

        public async Task Get_Gangs_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/gangs");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var gangs = JsonConvert.DeserializeObject<List<Gang>>(await response.Content.ReadAsStringAsync());
            Assert.True(gangs.Count > 0);
        }
        [Fact]

        public async Task Get_Outlaws_Should_Return_Ok()
        {
            var response = await Client.GetAsync("/outlaws");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var outlaws = JsonConvert.DeserializeObject<List<Outlaw>>(await response.Content.ReadAsStringAsync());
            Assert.True(outlaws.Count > 0);
        }
        [Fact]
        public async Task Add_Outlaw(){
            var outlaw = new OutlawDTO(){      
                OutlawUri= "https://dbpedia.org/resource/Jesse_James",
                Name =  "Henry Newton Brown",
                BirthDate =  null,
                DeathDate =  "1884-04-30",
                DeathCauseId =  Guid.Parse("b82f1cde-d0bc-46f8-bf90-f8092349a861"),
                Gangs =  null,
                Description =  "Henry Newton Brown (1857 – April 30, 1884) was an American Old West gunman who played the roles of both lawman and outlaw during his life. Brown was raised in Cold Springs Township, in Phelps County, ten miles south of Rolla, Missouri. An orphan, he lived there with his uncle Jasper and aunt Aldamira Richardson until the age of seventeen, when he left home and headed west. He drifted through various cowboy jobs in Colorado and Texas, supposedly killing a man in a gunfight in the Texas Panhandle."
            };

            string json = JsonConvert.SerializeObject(outlaw);
            var response = await Client.PostAsync("/outlaw", new StringContent(json, Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdOutlaw = JsonConvert.DeserializeObject<OutlawDTO>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(createdOutlaw);
            Assert.Equal<string>("Henry Newton Brown", createdOutlaw.Name);
        }

        [Fact]
        public async Task Add_Outlaw_Uri(){

            string uri = "http://dbpedia.org/resource/Jesse_James";

            var response = await Client.PostAsync($"/outlawuri?uri=http://dbpedia.org/resource/Barack_Obama", null);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var createdOutlaw = JsonConvert.DeserializeObject<Outlaw>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(createdOutlaw);
            Assert.Equal<string>("Barack Obama", createdOutlaw.Name);
        }
    }
}
