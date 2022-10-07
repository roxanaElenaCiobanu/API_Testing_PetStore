using API_Testing_PetStore.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_PetStore
{
    public class Api
    {

        private const string baseUrl = "https://petstore.swagger.io/v2/";

        private Helper helper;

        public Api()
        {
            helper = new Helper();
        }

        public RestResponse CreateNewUser ( string endpoint, dynamic payload_model)
        {

            /*   var client = new RestClient("https://petstore.swagger.io/v2");

               var request = new RestRequest("/user", Method.Post);
               request.AddHeader("Content-Type", "application/json");

               Dictionary<string, string> headers = new Dictionary<string, string>();

               headers.Add("accept", "application/json");
               headers.Add("Content-Type", "application/json");

               request.AddHeaders(headers);

               request.RequestFormat = DataFormat.Json;

               RestResponse response = client.Execute(request);

               var content = response.Content;

               NewUser newUser = JsonConvert.DeserializeObject<NewUser>(content);

               return newUser;
            */
             
            var client = helper.SetURL(baseUrl, endpoint);
            var payload = HandleContent.GetPayloadFromModel(payload_model);

            var request = helper.CreatePostRequest(payload);
            var response = helper.GetResponse(client, request);

            return response;
        }

       
        public RestResponse AddNewPetToStore(string endpoint, dynamic payload_model)
        {

            var client = helper.SetURL(baseUrl, endpoint);
            var payload = HandleContent.GetPayloadFromModel(payload_model);

            var request = helper.CreatePostRequest(payload);
            var response = helper.GetResponse(client, request);
            //var addnewpet = helper.GetContent<PetFromStoreRes>(response);

            return response;

        }

        public RestResponse FindPetByID(string endpoint, string petId)
        {


            var client = helper.SetURL(baseUrl, endpoint + petId);
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);

            //var petfound = HandleContent.GetContent<PetFromStoreRes>(response);

            return response; 
        }

        public RestResponse GetUserByUsername(string endpoint, string username)
        {


            var client = helper.SetURL(baseUrl, endpoint + username);
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);

            //var petfound = HandleContent.GetContent<PetFromStoreRes>(response);

            return response;
        }

    }
}
