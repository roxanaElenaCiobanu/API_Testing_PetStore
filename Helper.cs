using RestSharp;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API_Testing_PetStore
{
    public class Helper
    {

        private RestClient client;
        private RestRequest request;

        public RestClient SetURL(string baseUrl, string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);


            Console.WriteLine(url);

            client = new RestClient(url);
            return client;
        }
        public RestRequest CreateGetRequest()
        {
            request = new RestRequest("", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            return request;
        }
        public RestRequest CreatePostRequest(string payload)
        {
            request = new RestRequest("",Method.Post);
            Dictionary<string, string> headers = new Dictionary<string, string>();

            headers.Add("accept", "application/json");
            headers.Add("Content-Type", "application/json");

            request.AddHeaders(headers);
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;
        }
        public RestResponse GetResponse(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);

        }

        
    }
}
