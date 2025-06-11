namespace Assesment.Services
{
    public class ChangeOwnership : IChangeOwnership
    {
        private readonly HttpClient _httpClient;
        public ChangeOwnership(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
