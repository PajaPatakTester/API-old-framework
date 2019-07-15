using System;
using api_framework.Models;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace api_framework.Steps
{

    [Binding]
    public class GetResponsesSteps
    {
        private const string Url = "https://api.openweathermap.org/data/2.5/weather";

        private const string PictureUrl =
            "https://openweathermap.org/themes/openweathermap/assets/img/openweather-negative-logo-RGB.png";

        private RestClient _client;
        private RestRequest _request;
        private IRestResponse _response;

        [Given(@"I am connected")]
        public void GivenIAmConnected()
        {
            _client = new RestClient(Url);
        }

        [Given(@"I am requesting resource that is cached by browser")]
        public void GivenIAmRequestingResourceThatIsCachedByBrowser()
        {
            _client = new RestClient(PictureUrl);
        }

        [Given(@"I created request")]
        public void GivenICreatedRequest()
        {
            _request = new RestRequest(Method.GET);
        }

        [Given(@"I passed parameter (.*) and its value (.*)")]
        public void GivenIPassedParameterAndItsValue(string parameter, string value)
        {
            _request.AddParameter(parameter, value);
        }


        [Given(@"I passed API key")]
        public void GivenIPassedAPIKey()
        {
            _request.AddParameter("APPID", "53d1968dfb034b71be869593d68ef11c");
        }

        [Given(@"I set that resource is up to date with server")]
        public void GivenISetThatFileIsUpToDateWithServer()
        {
            var minuteBefore = DateTime.UtcNow.AddMinutes(-1);
            var formattedTime = minuteBefore.ToString("ddd dd MMM yyy HH:mm:ss") + " GMT";
            _request.AddHeader("If-Modified-Since", formattedTime);
        }

        [When(@"I send request")]
        public void WhenISendRequest()
        {
            _response = _client.Execute(_request);
        }

        [Then(@"result should be response Status (.*)")]
        public void ThenResultShouldBeResponseStatus(HttpResponses expectedStatus)
        {
            Assert.AreEqual(expectedStatus.ToString(), _response.StatusCode.ToString());
        }
    }
}
