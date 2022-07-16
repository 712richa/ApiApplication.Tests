using ApiApplication.Tests.TestSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ApiApplication.Tests
{
    [Binding]
    public sealed class Hooks
    {
        private readonly TestContext _context;
        private readonly ScenarioContext _scenario;
        private readonly UrlSettings _urlSettings;
        public Hooks(ScenarioContext scenarioContext, TestContext context, UrlSettings urlSettings)
        {
            _context = context;
            _scenario = scenarioContext;
            _urlSettings = urlSettings;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _context.client = new HttpClient
            {
                BaseAddress = new Uri(_urlSettings.CandidateTestUrl)
            };
        }
    }
}
