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
        //OnGetForecast(43.25408, -77.60178);
        BindingContext = this;
        GetDateTimeStamp();
        //PlayWebCamImages();


    }
    public async void Init()
    {
        AirTempChart.Series = InjectCharts(await OnGetForecast(43.1790, -77.5714));
    }
    public async Task<dynamic> OnGetForecast(double lon, double lat)
    {
        dynamic query = await FetchURLToJson($"https://api.weather.gov/points/{lon},{lat}");
        string forecastUrl = query.properties.forecast;
        dynamic forecast = await FetchURLToJson(forecastUrl);
        return forecast;
        //string forecastText = forecast.properties.periods[0].detailedForecast;
        //AirTempField.Text = forecast.properties.periods[0].temperature + " F";
        //string humidity = forecast.properties.periods[0].relativeHumidity + "%";
        //WindVelocityField.Text = forecast.properties.periods[0].windSpeed;
        //WindDirectionField.Text = forecast.properties.periods[0].windDirection;

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
    public Syncfusion.Maui.Charts.ChartSeriesCollection InjectCharts(dynamic dynamic)
    {
        ObservableCollection<double> airTemps = new ObservableCollection<double>();
        foreach (var period in dynamic.properties.periods)
        {
            double temperature = period.temperature;
            if (period.number! > 5) { airTemps.Add(temperature); }

        }
        return new Syncfusion.Maui.Charts.ChartSeriesCollection
            {
                new Syncfusion.Maui.Charts.LineSeries()
                {
                    ItemsSource =  new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Now", airTemps[0]),
                new ChartDataModel("+1", airTemps[1]),
                new ChartDataModel("+2", airTemps[2]),
                new ChartDataModel("+3", airTemps[3]),
                new ChartDataModel("+4", airTemps[4]),
                new ChartDataModel("+5", airTemps[5])

                 }
                    }
            };
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

       /* var timer = new System.Timers.Timer(5000);
        timer.Elapsed += (sender, e) =>
        {
            
            WebcamImage.Source = "https://cameras-cam.cdn.weatherbug.net/RCGLH/2023/11/06/110620231756_l.jpg";
        };
        timer.Start();
        timer.Elapsed += (sender, e) =>
        {

            WebcamImage.Source = $"https://cameras-cam.cdn.weatherbug.net/RCGLH/{year}/{month}/{day}/{month}{day}{year}{hour}{minute}_l.jpg";
        };
        timer.Start();*/





        //gRUrl2 = "https://cameras-cam.cdn.weatherbug.net/RCGLH/2023/11/06/110620231756_l.jpg";
        //WebcamImage.Source = gRUrl2;

        //gRUrl2 = $"https://cameras-cam.cdn.weatherbug.net/RCGLH/{year}/{month}/{day}/{month}{day}{year}{hour + 1}{minute}_l.jpg";


        //gRUrl3 = $"https://cameras-cam.cdn.weatherbug.net/RCGLH/{year}/{month}/{day}/{month}{day}{year}{hour + 1}{minute}_l.jpg";


        //gRUrl4 = $"https://cameras-cam.cdn.weatherbug.net/RCGLH/{year}/{month}/{day}/{month}{day}{year}{hour + 1}{minute}_l.jpg";


        //return gRUrl;


    }
    //public async void PlayWebCamImages()
    //{
    //   gRUrl2 = "https://cameras-cam.cdn.weatherbug.net/RCGLH/2023/11/06/110620231756_l.jpg";
    //   // WebcamImage.Source = gRUrl2;

    //    //gRUrl3 = $"https://cameras-cam.cdn.weatherbug.net/RCGLH/{year}/{month}/{day}/{month}{day}{year}{hour + 1}{minute}_l.jpg";
    //    //await WebcamImage.Source = gRUrl3;

    //    //gRUrl4 = $"https://cameras-cam.cdn.weatherbug.net/RCGLH/{year}/{month}/{day}/{month}{day}{year}{hour + 1}{minute}_l.jpg";
    //    //await WebcamImage.Source = gRUrl4;

    //}
}