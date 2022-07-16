using FluentAssertions;
using FluentAssertions.Extensions;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace ApiApplication.Tests.StepDefinitions.Then
{
    [Binding]
    public class ThenNewOrderAddded
    {
        private readonly TestContext _context;
        public ThenNewOrderAddded(TestContext context)
        {
            _context = context;
        }

        [Then(@"new item should be added")]
        public void ThenNewItemShouldBeAdded()
        {
            var OrdersList = JArray.Parse(_context.httpGetOrdersResponse.Content.ReadAsStringAsync().Result);
            if (_context.orderId != null)
            {
                JObject order = (JObject)OrdersList.FirstOrDefault(c => (string)c["id"] == _context.orderId);

                if (order != null)
                {
                    order.Value<string>("fuel").Should().Be(_context.energyType);
                    order.Value<int>("quantity").Should().Be(_context.quantity);
                    order.Value<DateTime>("time").ToLocalTime().Should().BeCloseTo(_context.Time.ToLocalTime(), 5.Seconds());

                }
            }

        }
    }
}

