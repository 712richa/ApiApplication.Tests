using ApiApplication.Tests.Support;
using TechTalk.SpecFlow;

namespace ApiApplication.Tests.StepDefinitions.Given
{
    [Binding]
    public class GivenICheckEnergyStock
    {
        private readonly TestContext _context;
        private HttpClientHelper _httpClientHelper;
        public GivenICheckEnergyStock(TestContext context)
        {
            _context = context;
            _httpClientHelper = new HttpClientHelper(_context);
        }

        [Given(@"I check the energy stock")]
        public async Task GivenICheckTheEnergyStock()
        {
            await _httpClientHelper.GetEnergyAsync();
        }

    }
}
