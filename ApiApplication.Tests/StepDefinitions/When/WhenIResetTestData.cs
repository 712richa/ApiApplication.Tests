using ApiApplication.Tests.Support;
using ApiApplication.Tests.TestSettings;
using TechTalk.SpecFlow;

namespace ApiApplication.Tests.StepDefinitions.When
{
    [Binding]
    public class WhenIResetTestData
    {
        private readonly TestContext _context;
        private HttpClientHelper _httpClientHelper;
        public WhenIResetTestData(TestContext  context)
        {
            _context = context;
            _httpClientHelper = new HttpClientHelper( _context);
        }

        [Given(@"I hit reset endpoint with authorised token")]
        [When(@"I hit reset endpoint with authorised token")]
        public async Task WhenIHitResetEndpoint()
        {
            await _httpClientHelper.ResetTestDataAsync();
            _context.httpResetResponse.EnsureSuccessStatusCode();
        }

        [When(@"I check the order")]
        public async Task WhenICheckTheOrder()
        {
            await _httpClientHelper.GetOrdersAsync();
        }


        [When(@"I hit reset endpoint with unauthorised token")]
        public async Task WhenIHitResetEndpointWithUnauthorisedUser()
        {
            await _httpClientHelper.ResetTestDataWithUnauthorisedUserAsync();
        }
    }
}
