using System.Text.Json;
using LAB9.Models;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "a94801febf9effd6211956d339c32a7c";

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherModel> GetWeatherAsync(string region)
    {
        var response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={region}&appid={ApiKey}&units=metric");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var jsonDocument = JsonDocument.Parse(content);

        return new WeatherModel
        {
            City = jsonDocument.RootElement.GetProperty("name").GetString(),
            Description = jsonDocument.RootElement.GetProperty("weather")[0].GetProperty("description").GetString(),
            Temperature = jsonDocument.RootElement.GetProperty("main").GetProperty("temp").GetDouble()
        };
    }
}
