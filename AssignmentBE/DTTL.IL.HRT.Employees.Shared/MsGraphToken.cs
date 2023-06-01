using System;
using System.Net.Http;
using System.Text.Json;

namespace DTTL.IL.HRT.Employees.Shared
{
    public interface IMSGraphToken
    {
        Task<List<UserModel>> GetAllHRTUsers();
    }
    public class MSGraphToken : IDisposable,IMSGraphToken
    {

        private readonly HttpClient _httpClient;
        public MSGraphToken(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<UserModel>> GetAllHRTUsers()
        {
            string url = $"{_httpClient.BaseAddress}user";
            List<UserModel> GraphUsers = new();
            try
            {
                var response = await _httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
                JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };
                GraphUsers = JsonSerializer.Deserialize<List<UserModel>>(response, _options);
            }
            catch (Exception ex)
            {

            }
            return GraphUsers;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}

