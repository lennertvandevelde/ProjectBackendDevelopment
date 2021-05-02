using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Outlaws.API.Models;

namespace Outlaws.API.Services
{
    public interface ISPARQLService
    {
        HttpClient Client { get; set; }

        Task<Outlaw> GetOutlaw(string uri);
    }

    public class SPARQLService : ISPARQLService
    {
        public HttpClient Client { get; set; }

        public async Task<Outlaw> GetOutlaw(string uri)
        {
            try
            {

                HttpResponseMessage response = await Client.GetAsync($"https://api.triplydb.com/queries/lennertvdv999/SingleOutlaw-1/run?uriname={uri}");
                response.EnsureSuccessStatusCode();
                Outlaw outlaw = JsonConvert.DeserializeObject<Outlaw>(await response.Content.ReadAsStringAsync());
                return outlaw;
            }
            catch (Exception e)
            {
                throw e;
            }


        }
    }
}
