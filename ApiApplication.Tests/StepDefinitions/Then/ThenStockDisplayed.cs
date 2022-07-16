using ApiApplication.Tests.Support;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace ApiApplication.Tests.StepDefinitions.Then
{
    [Binding]
    public class ThenStockDisplayed
    {
        private readonly TestContext _context;

        private HttpClientHelper _httpClientHelper;
        public ThenStockDisplayed(TestContext context)
        {
            _context = context;

            _httpClientHelper = new HttpClientHelper(_context);
        }

        [Then(@"""([^""]*)"" message is displayed")]
        public void ThenMessageIsDisplayed(string p0)
        {
            var actualMessage = _context.httpBuyEnergyResponse.Content.ReadAsStringAsync().Result;
            actualMessage.ToString().Should().Contain(p0);
        }

        [Then(@"it should display upto date stock")]
        public async Task ThenItShouldDisplayUptoDateStock()
        {
            var previousStockList = _context.httpGetEnergyResponse.Content.ReadAsStringAsync().Result;

            var previousStock = JObject.Parse(previousStockList)[_context.energyType];

            Console.WriteLine($"Previous Stock: {previousStock}");

            //Taking shortcut here:

            await _httpClientHelper.GetEnergyAsync();

            var newStockList = _context.httpGetEnergyResponse.Content.ReadAsStringAsync().Result;

            var newStockLeft = JObject.Parse(newStockList)[_context.energyType];
            Console.WriteLine($"New Stock: {newStockLeft}");

            newStockLeft.Value<int>("quantity_of_units").Should().Be(previousStock.Value<int>("quantity_of_units") - _context.quantity);



            //if (order != null)
            //{
            //    order.Value<string>("fuel").Should().Be(_context.energyType);
            //    order.Value<int>("quantity").Should().Be(_context.quantity);
            //    order.Value<DateTime>("time").ToLocalTime().Should().BeCloseTo(_context.Time.ToLocalTime(), 5.Seconds());

            //}
        }


    }
}
