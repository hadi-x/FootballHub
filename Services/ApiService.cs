using FootballHub.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace FootballHub.Services
{
    public class ApiService
    {

        private readonly HttpClient _client;

        public ApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<APiResults> GetMatchesAsync(string leagueCode, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var requestUrl = $"v4/competitions/{leagueCode}/matches?dateFrom={fromDate:yyyy-MM-dd}&dateTo={toDate:yyyy-MM-dd}";

                var response = await _client.GetAsync(requestUrl);
 

                if (!response.IsSuccessStatusCode)
                {
                    // بررسی وضعیت پاسخ "TooManyRequests" (429)
                    if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                    {
                        throw new Exception("Too many requests. Please try again later.");
                    }

                    throw new Exception($"API request failed with status code {response.StatusCode}: {response.ReasonPhrase}");
                }

                string content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<APiResults>(content);

                return apiResponse;
            }
            catch (HttpRequestException httpEx)
            {
                 
                throw new Exception(httpEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<APiResults>> CallService(int fdate,int tdate)
        {
            DateTime fromDate = DateTime.Now.AddDays(fdate);
            DateTime toDate = DateTime.Now.AddDays(tdate);

            var leagueCodes = new List<string> { "PL", "PPL", "DED", "BL1", "SA", "PD", "BSA" };

            List<APiResults> allMatches = new List<APiResults>();

            var tasks = new List<Task>();
            foreach (var leagueCode in leagueCodes)
            {
                tasks.Add(Task.Run(async () =>
                {
                    var matches = await GetMatchesAsync(leagueCode, fromDate, toDate);
                    allMatches.Add(matches);
                }));
            }

            await Task.WhenAll(tasks);
        
            return allMatches.OrderByDescending(match => match.resultSet.count).ToList();  
        }
    }
}
