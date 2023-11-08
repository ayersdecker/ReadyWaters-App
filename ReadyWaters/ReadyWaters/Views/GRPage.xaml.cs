using Newtonsoft.Json;

namespace ReadyWaters.Views;

public partial class GRPage : ContentPage
{
	public GRPage()
	{
		InitializeComponent();
        OnGetForecast(43.2540828, -77.6017813);
        InjectVideo();
    }

    public void InjectVideo()
    {
        HtmlWebViewSource hal = new HtmlWebViewSource();
        string iframeHtml = $@"
                <html>
                    <body>
                        <iframe width='370' height='250' src='https://www.youtube.com/embed/R3doZOF9Yis?autoplay=0&showinfo=0&controls=0' frameborder='0' allow='autoplay'></iframe>
                    </body>
                </html>";
        hal.Html = iframeHtml;
        Video.Source = hal;
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