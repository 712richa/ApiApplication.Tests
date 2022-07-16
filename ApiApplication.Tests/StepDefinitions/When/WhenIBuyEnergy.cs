using ApiApplication.Tests.Support;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace ApiApplication.Tests.StepDefinitions.When
{
    [Binding]
    public class WhenIBuyEnergy
    {
        private readonly TestContext _context;
        private HttpClientHelper _httpClientHelper;
        public WhenIBuyEnergy(TestContext context)
        {
            _context = context;
            _httpClientHelper = new HttpClientHelper(_context);
        }

        [When(@"When I buy (.*) for (.*) unit")]
        public async Task WhenWhenIBuyForQuanityUnit(string energyType, int quantity)
        {
            _context.energyType = energyType;
            _context.quantity = quantity;
            _context.Time = DateTime.UtcNow;
            int energyId = 0;
            switch (energyType)
            {
                case "gas":
                    energyId = 1;
                    break;
                case "nuclear":
                    energyId = 2;
                    break;
                case "elec":
                    energyId = 3;
                    break;
                case "oil":
                    energyId = 4;
                    break;
                default:
                    throw new Exception("Unexpected Energy type");
                    break;
            }

            await _httpClientHelper.BuyEnergyAsync(energyId, quantity);
        }

    }
}
