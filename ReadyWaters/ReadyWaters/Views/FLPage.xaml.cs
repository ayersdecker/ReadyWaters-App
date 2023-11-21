using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace ReadyWaters.Views;

public partial class FLPage : ContentPage
{
    public DateTime DateTimeNow { get; set; }
    public string fLUrl { get; set; }
    public FLPage()
	{
		InitializeComponent();
        OnGetForecast(43.2487, -77.4996);
        WebcamImage.Source = "https://www.weatherbug.com/weather-camera/?cam=WBSTR";
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
    public void GetDateTimeStamp()
    {

        DateTimeNow = DateTime.Now;
        string year = DateTimeNow.Year.ToString();
        string month = DateTimeNow.ToString("MM");
        string day = DateTimeNow.ToString("dd");
        string hour = ((DateTimeNow.Hour) - 1).ToString();
        string minute = "29";//DateTimeNow.ToString();IF THE CAMERA SOURCE GETS OUT OF SYNC, THERE COULD BE A PROBLEM AND THIS VALUE "56", REPRESENTING MINUTES IN THE URL, MAY HAVE TO CHANGE

        //fLUrl = $"https://www.weatherbug.com/weather-camera/?cam=WBSTR/{year}/{month}/{day}/{month}{day}{year}{hour}{minute}_l.jpg";
        //fLUrl = "https://www.weatherbug.com/weather-camera/?cam=WBSTR";

        WebcamImage.Source = $"https://cameras-cam.cdn.weatherbug.net/WBSTR/{year}/{month}/{day}/{month}{day}{year}{hour}{minute}_l.jpg";
        //WebcamImage.Source = fLUrl;

        //return gRUrl;

    }
}