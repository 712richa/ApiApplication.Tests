using FluentAssertions;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace ApiApplication.Tests.StepDefinitions.Then
{
    [Binding]
    public  class ThenResponseReturned
    {

        private readonly TestContext _context;
        public ThenResponseReturned(TestContext context)
        {
                _context = context;
        }

        [Then(@"it should return success response")]
        public void ThenItShouldReturnSuccessResponse()
        {
            _context.httpGetOrdersResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Then(@"it should return unauthorised response")]
        public void ThenItShouldReturnUnauthorisedResponse()
        {
            _context.httpResetResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }

        [Then(@"data should be rest")]
        public void ThenDataShouldBeRest()
        {
            var actualOrders = JArray.Parse(_context.httpGetOrdersResponse.Content.ReadAsStringAsync().Result);
            var actualOrdersCount = actualOrders.OfType<JObject>().ToList().Count();

            actualOrdersCount.Should().Be(5);
        }

    }
}
