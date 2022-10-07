using API_Testing_PetStore.Models;
using NUnit.Framework;
using System.Diagnostics;
using System.Net;
using System.Net.WebSockets;

namespace API_Testing_PetStore
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        private HttpStatusCode statusCode;
        private const string baseUrl = "https://petstore.swagger.io/v2/";

        [Test]
        public void CreateNewUserTest()
        {
            //payload se declara doar cand ai metoda POST
            string payload = @"{
                                    ""id"": 2,
                                    ""username"": ""tt1"",
                                    ""firstName"": ""gg1"",
                                    ""lastName"": ""ser"",
                                    ""email"": ""x@x.com"",
                                    ""password"": ""gfgf"",
                                    ""phone"": ""1234555"",
                                    ""userStatus"": 5
                                }";
            var api = new Api();
            var response = api.CreateNewUser( "user", payload);
            statusCode = response.StatusCode;
            var code = (int)statusCode;

            Assert.AreEqual(200, code);

            var newusers = HandleContent.GetContent<NewUserRes>(response);

            Assert.AreEqual("2", newusers.message);
            Assert.AreEqual(200, newusers.code);
        }

        [Test]
        public void AddPetToStore()
        {
            //payload se declara doar cand ai metoda POST
            string payload = @"{
                                    ""id"": 1,
                                    ""category"": {
                                        ""id"": 2,
                                        ""name"": ""test""
                                    },
                                    ""name"": ""sam"",
                                    ""photoUrls"": [
                                        ""string""
                                    ],
                                    ""tags"": [
                                      {
                                        ""id"": 1,
                                        ""name"": ""tag1""
                                      }
                                    ],
                                    ""status"": ""available""
                                }";

            var api = new Api();
            var response = api.AddNewPetToStore( "", payload );
            statusCode = response.StatusCode;
            var code = (int)statusCode;

            Assert.AreEqual(200, code);

            var newPetContent = HandleContent.GetContent<PetFromStoreRes>(response);
            
            Assert.AreEqual(1, newPetContent.id);
            Assert.AreEqual(2, newPetContent.category.id);
            Assert.AreEqual("sam", newPetContent.name);
            Assert.AreEqual("tag1", newPetContent.tags[0].name);



        }


        [Test]
        public void GetPetByID()
        {
           

            var api = new Api();
            var response = api.FindPetByID( "", "1");
            statusCode = response.StatusCode;
            var code = (int)statusCode;

            Assert.AreEqual(200, code);

            var petfound = HandleContent.GetContent<PetFromStoreRes>(response);

            Assert.AreEqual(1, petfound.id);
            Assert.AreEqual(2, petfound.category.id);
            Assert.AreEqual("sam", petfound.name);
            Assert.AreEqual("tag1", petfound.tags[0].name);



        }

    }
}