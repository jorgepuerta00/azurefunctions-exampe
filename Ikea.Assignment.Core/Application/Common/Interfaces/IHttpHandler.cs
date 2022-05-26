namespace IkeaAssignmentCore.Application.Common.Interfaces
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IHttpHandler
    {
        Task<string> GetStringAsync(string url);
    }
}
