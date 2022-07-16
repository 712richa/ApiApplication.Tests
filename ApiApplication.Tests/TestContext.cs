using TechTalk.SpecFlow;
namespace ApiApplication.Tests
{
    public class TestContext
    {
        public ScenarioContext Context { get; }
        public TestContext(ScenarioContext context)
        {
            Context = context;
        }
        public string authToken
        {
            get => Context.Get<string>("authToken");
            set => Context["authToken"] = value;
        }
        public HttpClient client
        {
            get => Context.Get<HttpClient>("client");
            set => Context["client"] = value;
        }

        public HttpResponseMessage httpResetResponse
        {
            get => Context.Get<HttpResponseMessage>("httpResetResponse");
            set => Context["httpResetResponse"] = value;
        }

        public HttpResponseMessage httpGetOrdersResponse
        {
            get => Context.Get<HttpResponseMessage>("httpGetOrdersResponse");
            set => Context["httpGetOrdersResponse"] = value;
        }

        public HttpResponseMessage httpBuyEnergyResponse
        {
            get => Context.Get<HttpResponseMessage>("httpBuyEnergyResponse");
            set => Context["httpBuyEnergyResponse"] = value;
        }

        public HttpResponseMessage httpGetEnergyResponse
        {
            get => Context.Get<HttpResponseMessage>("httpGetEnergyResponse");
            set => Context["httpGetEnergyResponse"] = value;
        }

        public string orderId
        {
            get => Context.Get<string>("orderId");
            set => Context["orderId"] = value;
        }
        public int quantity
        {
            get => Context.Get<int>("quantity");
            set => Context["quantity"] = value;
        }
        public string energyType
        {
            get => Context.Get<string>("energyType");
            set => Context["energyType"] = value;
        }
        public DateTime Time
        {
            get => Context.Get<DateTime>("Time");
            set => Context["Time"] = value;
        }
    }
}
