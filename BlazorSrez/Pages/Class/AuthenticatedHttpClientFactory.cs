using System.Net.Http.Headers;

namespace BlazorSrez.Pages.Class
{
    public class AuthenticatedHttpClientFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AuthenticatedHttpClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<HttpClient> CreateClientAsync()
        {
            var client = new HttpClient { BaseAddress = new Uri("https://localhost:7125/") };

            // Получаем сервис localStorage
            var localStorage = _serviceProvider.GetRequiredService<LocalStorageService>();
            var token = await localStorage.GetItem("jwtToken"); // Асинхронное получение токена

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }
    }
}
