using Microsoft.AspNetCore.Mvc;

namespace CPProgressTrackerWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CPTrackerController : ControllerBase
    {

        [HttpPost(Name = "GetAccountInformation")]
        public async Task<string> GetAccountInformation([FromBody] string userAlias)
        {
            string result = null;
            using (HttpClient client = new HttpClient())
            {
                string accountInfoEndpoint = $"https://codeforces.com/api/user.info?handles={userAlias}";
                client.BaseAddress = new Uri(accountInfoEndpoint);
                HttpResponseMessage response = client.GetAsync(userAlias).Result;

                result = response.Content.ReadAsStringAsync().Result;
            }
            return result;
        }

        [HttpPost(Name = "GetUserData")]
        public string GetUserData(string userAlias)
        {
            string result = null;
            HttpClient client = new HttpClient();
            string userDataendpoint = $"https://codeforces.com/api/user.status?handle={userAlias}";
            client.BaseAddress = new Uri(userDataendpoint);
            HttpResponseMessage response = client.GetAsync(userAlias).Result;

            result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
