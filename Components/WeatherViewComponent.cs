using Microsoft.AspNetCore.Mvc;

public class WeatherViewComponent : ViewComponent
{
    private readonly WeatherService _weatherService;

    public WeatherViewComponent(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string region)
    {
        var weather = await _weatherService.GetWeatherAsync(region);
        return View(weather);
    }
}
