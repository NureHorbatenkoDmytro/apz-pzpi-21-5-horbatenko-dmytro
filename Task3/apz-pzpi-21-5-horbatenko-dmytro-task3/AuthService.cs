using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FloraSenseIoT
{


    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _authUrl = "http://localhost:3000/api/auth/login";

        public AuthService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var requestBody = new
            {
                email = email,
                password = password
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, _authUrl)
            {
                Content = content
            };
            request.Headers.Add("User-Agent", "IoT");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<AuthResponse>(responseContent).AccessToken;

            return token;
        }

        public class AuthResponse
        {
            [JsonProperty("accessToken")]
            public string AccessToken { get; set; }
        }

    }

}
