using API_Testing_PetStore.Models;
using Gherkin.Ast;
using RestSharp;
using System.Collections;
using System.Data;
using System.Net;
using TechTalk.SpecFlow;

namespace API_Testing_PetStore.StepsDefinition
{
    [Binding]
    public class Users
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly UserModel userModel;
        private RestResponse response;

        public Users (UserModel userModel)
        {

            this.userModel = userModel;

        }

        [Given(@"I input id as '(.*)'")]
        public void GivenIInputIdAs(string id)
        {
            userModel.id = int.Parse(id);
        }

        [Given (@"I input username as '(.*)'")]

        public void IInputUsername(String username)
        {

            userModel.username = username;

        }

        [Given(@"I input firstname  '(.*)'")]
        public void GivenIInputFirstname(string firstname)
        {
            userModel.firstName = firstname;
        }

        [Given(@"I input lastname '(.*)'")]
        public void GivenIInputLastname(string lastname)
        {
            userModel.lastName = lastname;

        }

        [Given(@"I input email '(.*)'")]
        public void GivenIInputEmail(string email)
        {
            userModel.email = email;
        }

        [Given(@"I input password '(.*)'")]
        public void GivenIInputPassword(string password)
        {
            userModel.password = password;
        }

        [Given(@"I input phone '(.*)'")]
        public void GivenIInputPhone(string phone)
        {
            userModel.phone = phone;
        }

        [Given(@"I input userstatus '(.*)'")]
        public void GivenIInputUserstatus(string userstatus)
        {
            userModel.userStatus = int.Parse( userstatus);
        }

        [When(@"I send create new user request")]
        public void WhenISendCreateNewUserRequest()
        {

            var api = new Api();
            response = api.CreateNewUser( "user", userModel);

        }

        [Then(@"I see that a valid user is created")]
        public void ThenISeeThatAValidUserIsCreated()
        {
            var content = HandleContent.GetContent<NewUserRes>(response);

            Assert.AreEqual(userModel.id, int.Parse(content.message));
            Assert.AreEqual(200, content.code);
        }

        [When(@"I send get user by username request")]
        public void WhenISendGetUserByUsernameRequest()
        {
            var api = new Api();
            response = api.GetUserByUsername("user/", userModel.username);
        }


        [Then(@"I receive status code '(.*)'")]
        public void ThenIReceiveStatusCode(string expectedStatusCode)
        {
            HttpStatusCode actualStatusCode = response.StatusCode;
            var code = (int)actualStatusCode;

            Assert.AreEqual(expectedStatusCode, code.ToString());
        }

        [Then(@"I receive the details for the requested username")]
        public void ThenIReceiveTheDetailsForTheRequestedUsername(Table table)
        {

            var content = HandleContent.GetContent<UserModel>(response);
            Console.WriteLine("cell = " + table.Rows[0][1].ToString());

            Assert.AreEqual(table.Rows[0][0], content.id.ToString());
            Assert.AreEqual(table.Rows[0][1], content.username);
            Assert.AreEqual(table.Rows[0][2], content.firstName);
            Assert.AreEqual(table.Rows[0][3], content.lastName);
            Assert.AreEqual(table.Rows[0][4], content.email);
            Assert.AreEqual(table.Rows[0][5], content.password);
            Assert.AreEqual(table.Rows[0][6], content.phone);
            Assert.AreEqual(table.Rows[0][7], content.userStatus.ToString());

            

        }

    }


}
