using Newtonsoft.Json;

namespace ReadyWaters.Views;

public partial class FLPage : ContentPage
{
	public FLPage()
	{
		InitializeComponent();
        OnGetForecast(43.24872, -77.49967);
	}
    public async void OnGetForecast(double lon, double lat)
    {
        dynamic query = await FetchURLToJson($"https://api.weather.gov/points/{lon},{lat}");
        string forecastUrl = query.properties.forecast;
        dynamic forecast = await FetchURLToJson(forecastUrl);

        string forecastText = forecast.properties.periods[0].detailedForecast;
        AirTempField.Text = forecast.properties.periods[0].temperature + " F";
        string humidity = forecast.properties.periods[0].relativeHumidity + "%";
        WindVelocityField.Text = forecast.properties.periods[0].windSpeed;
        WindDirectionField.Text = forecast.properties.periods[0].windDirection;

    }
    public async Task<dynamic> FetchURLToJson(string url)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
        client.DefaultRequestHeaders.Add("User-Agent", "WaterReady");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        HttpResponseMessage response = await client.GetAsync(url);
        //response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<dynamic>(content);
    }
}