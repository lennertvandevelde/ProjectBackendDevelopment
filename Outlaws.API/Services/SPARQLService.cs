using System;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Outlaws.API.Models;

namespace Outlaws.API.Services
{
    public interface ISPARQLService
    {


        Task<Outlaw> GetOutlaw(string uri);
    }

    public class SPARQLService : ISPARQLService
    {


        public async Task<Outlaw> GetOutlaw(string uri)
        {
            try
            {
                
                var client = new RestClient($"https://api.triplydb.com/queries/lennertvdv999/SingleOutlaw-1/run?uriname={uri}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);
                Outlaw outlaw = JsonConvert.DeserializeObject<Outlaw>(response.Content.TrimStart('[').TrimEnd(']'));
                outlaw.OutlawId = Guid.NewGuid();
                outlaw.OutlawUri = uri;
                outlaw.DeathCauseId = new Guid("0502be48-d9c7-46b2-80bc-726fbc2f0b6c");
                return outlaw;
            }
            catch (Exception e)
            {
                throw e;
            }


        }
    }
}
