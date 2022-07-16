using ApiApplication.Tests.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ApiApplication.Tests.Support
{
    public class HttpClientHelper
    {
        private readonly TestContext _context;  
        public HttpClientHelper(TestContext context)
        {
            _context = context;
        }

        public async Task<HttpResponseMessage> ResetTestDataAsync()
        {
            _context.client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_context.authToken}");
            var response = await _context.client.PostAsync("/reset",null);
            _context.httpResetResponse = response;
            return response;
        }

        public async Task<HttpResponseMessage> GetEnergyAsync()
        {
           // _context.client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_context.authToken}");
            var response = await _context.client.GetAsync("/energy");
            _context.httpGetEnergyResponse = response;
            return response;
        }

        public async Task<HttpResponseMessage> BuyEnergyAsync(int energyType, int quantity)
        {
            var request = new BuyEnergyRequest
            {
                EnergyType = energyType,
                Quantity = quantity
            };
            //Console.WriteLine($"Auth Token: {_context.authToken}");
            _context.client.DefaultRequestHeaders.Clear();
            _context.client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_context.authToken}");
            _context.httpBuyEnergyResponse = await _context.client.PutAsync($"/buy/{energyType}/{quantity}", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            Console.WriteLine($"Response returned: {_context.httpBuyEnergyResponse.Content.ReadAsStringAsync().Result}");

            if (!_context.httpBuyEnergyResponse.Content.ReadAsStringAsync().Result.Contains($"There is no"))
                GetOrderId();
            else
                _context.orderId = null;

            return _context.httpBuyEnergyResponse;
        }

        public string GetOrderId()
        {
            string response = _context.httpBuyEnergyResponse.Content.ReadAsStringAsync().Result;
            string pattern = @"(?<= is ).*";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(response, pattern, options))
            {
                _context.orderId = m.Value.TrimEnd('.', '"', '}');
                Console.WriteLine($"Order Id: {_context.orderId}");
            }

            return _context.orderId;
        }

        public async Task<HttpResponseMessage> ResetTestDataWithUnauthorisedUserAsync()
        {
            _context.client.DefaultRequestHeaders.Add("Authorization", $"Bearer blah");
            var response = await _context.client.PostAsync("/reset", null);
            _context.httpResetResponse = response;
            return response;
        }
        public async Task<HttpResponseMessage> GetOrdersAsync()
        {
            //_context.client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_context.authToken}");
            var response = await _context.client.GetAsync("/orders");
            _context.httpGetOrdersResponse = response;
            return response;
        }

        public async Task<string> GetAuthToken(string username, string password)
        {
            var request = new LoginRequest
            {
                UserName = username,
                Password = password
            };
            var response = await _context.client.PostAsync("/login", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                var i = 0;
                while ((response.StatusCode == HttpStatusCode.InternalServerError) && i < 10)
                {
                    Console.WriteLine($"Login request retured {response.StatusCode}. Retrying.");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    response = await _context.client.PostAsync("/login", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
                    i++;
                }
            }

            var result = await response.Content.ReadAsStringAsync();
            var responseBody = JsonConvert.DeserializeObject<LoginResponse>(result);

            if (response.IsSuccessStatusCode)
            {
                _context.authToken = responseBody.AccessToken;
                Console.WriteLine($"AuthToken: {_context.authToken}");
                return responseBody.AccessToken;
            }
            else
                return responseBody.Message;
        }
    }
}
