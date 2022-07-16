using FluentAssertions;
using TechTalk.SpecFlow;

namespace ApiApplication.Tests.StepDefinitions.Then
{
    [Binding]
    public class ThenStockMessageDsiplayed
    {
        private readonly TestContext _context;
        public ThenStockMessageDsiplayed(TestContext context)
        {
            _context = context;
        }

        [Then(@"""([^""]*)"" message is displayed")]
        public void ThenMessageIsDisplayed(string p0)
        {
            var actualMessage = _context.httpBuyEnergyResponse.Content.ReadAsStringAsync().Result;
            actualMessage.ToString().Should().Contain(p0);
        }

    }
}
