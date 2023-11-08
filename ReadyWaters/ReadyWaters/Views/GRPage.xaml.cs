using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace ReadyWaters.Views;

public partial class GRPage : ContentPage
{
    public DateTime DateTimeNow { get; set; }
    public string gRUrl { get; set; }

	public GRPage()
	{
		InitializeComponent();
        OnGetForecast(43.2540828, -77.6017813);
        BindingContext = this;       
        GetDateTimeStamp();
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
    public string GetDateTimeStamp()
    {

        DateTimeNow = DateTime.Now;
        string year = DateTimeNow.Year.ToString();
        string month = DateTimeNow.Month.ToString();
        string day = DateTimeNow.Day.ToString();
        string hour = ((DateTimeNow.Hour) - 1).ToString();
        string minute = DateTimeNow.Minute.ToString();
        
        gRUrl = $"https://cameras-cam.cdn.weatherbug.net/rcglh/{year}/{month}/{day}/{month}{day}{year}{hour}{minute}_l.jpg";
        //WebcamImage.Source = $"https://cameras-cam.cdn.weatherbug.net/rcglh/{year}/{month}/{day}/{month}{day}{year}{hour}{minute}_l.jpg";
        //webcamimage.source = new uri(grurl);
        return gRUrl;

    }
}