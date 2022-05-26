namespace IkeaAssignmentCore.Application.Common.HttpClientHandler
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using IkeaAssignmentCore.Application.Common.Interfaces;

    public class HttpClientHandler : IHttpHandler
    {
        private HttpClient _client = new HttpClient();

        public async Task<string> GetStringAsync(string url)
        {
            return await _client.GetStringAsync(url);
        }
    }
}
