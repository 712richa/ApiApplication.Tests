using ApiApplication.Tests.Support;
using TechTalk.SpecFlow;

namespace ApiApplication.Tests.StepDefinitions.Given
{

    [Binding]
    public class GivenIamOnEnsekCandidateTestApplication
    {
        private readonly TestContext _context;
        private HttpClientHelper _httpClientHelper;
        public GivenIamOnEnsekCandidateTestApplication( TestContext context)
        {
            _context = context;

            _httpClientHelper = new HttpClientHelper( _context);
        }

        [Given(@"I am an '([^']*)' user")]
        public async Task GivenIAmAnUser(string p0)
        {
            switch (p0)
            {
                case "authorised":
                    await _httpClientHelper.GetAuthToken("test", "testing");
                    break;
                case "unauthorised":
                    await _httpClientHelper.GetAuthToken("test", "testing123");
                    break;
                default:
                    Console.WriteLine("Invalid user type");
                    break;
            }
        }
    }
}
