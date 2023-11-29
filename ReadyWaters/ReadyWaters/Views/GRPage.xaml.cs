using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using System.Timers;
using System.Collections.ObjectModel;
using ReadyWaters.ViewModels;

namespace ReadyWaters.Views;

public partial class GRPage : ContentPage
{
    public DateTime DateTimeNow { get; set; }
    public string gRUrl { get; set; }
    public string gRUrl2 { get; set; }
    public string gRUrl3 { get; set; }
    public string gRUrl4 { get; set; }

    public GRPage()
	{
		InitializeComponent();
        OnGetForecast(43.25408, -77.60178);
        BindingContext = this;
        GetDateTimeStamp();


    }
    
    public async Task<dynamic> OnGetForecast(double lon, double lat)
    {
        dynamic query = await FetchURLToJson($"https://api.weather.gov/points/{lon},{lat}");
        string forecastUrl = query.properties.forecast;
        dynamic forecast = await FetchURLToJson(forecastUrl);
        
        string forecastText = forecast.properties.periods[0].detailedForecast;
        AirTempField.Text = forecast.properties.periods[0].temperature + " F";
        string humidity = forecast.properties.periods[0].relativeHumidity + "%";
        WindVelocityField.Text = forecast.properties.periods[0].windSpeed;
        WindDirectionField.Text = forecast.properties.periods[0].windDirection;

        return forecast;

    }
    public async Task<dynamic> FetchURLToJson(string url)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
        client.DefaultRequestHeaders.Add("User-Agent", "WeatherToGo");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        HttpResponseMessage response = await client.GetAsync(url);
        //response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<dynamic>(content);
    }

    public async void GetDateTimeStamp()
    {

        DateTimeNow = DateTime.Now;
        string year = DateTimeNow.Year.ToString();
        string month = DateTimeNow.ToString("MM");
        string day = DateTimeNow.ToString("dd");
        string hour = ((DateTimeNow.Hour) - 1).ToString();
        string minute = "56";//DateTimeNow.ToString();IF THE CAMERA SOURCE GETS OUT OF SYNC, THERE COULD BE A PROBLEM AND THIS VALUE "56", REPRESENTING MINUTES IN THE URL, MAY HAVE TO CHANGE

        gRUrl = $"https://cameras-cam.cdn.weatherbug.net/RCGLH/{year}/{month}/{day}/{month}{day}{year}{hour}{minute}_l.jpg";


        WebcamImage.Source = gRUrl;
    }
}