using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using Newtonsoft.Json;
using ReadyWaters.ViewModels;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace ReadyWaters.Views;

public partial class IBPage : ContentPage
{
    public DateTime DateTimeNow { get; set; }
    public string gRUrl { get; set; }
    public string gRUrl2 { get; set; }
    public string gRUrl3 { get; set; }
    public string gRUrl4 { get; set; }
    public ObservableCollection<ChartDataModel> LineData1 { get; set; } = new ObservableCollection<ChartDataModel>();
    public ObservableCollection<ChartDataModel> LineData2 { get; set; } = new ObservableCollection<ChartDataModel>();
    public ObservableCollection<ChartDataModel> LineData3 { get; set; } = new ObservableCollection<ChartDataModel>();

    public IBPage()
    {
        InitializeComponent();
        //OnGetForecast(43.1790113, -77.5714571);
        //Init();
        //GetDateTimeStamp();
        //Webcam.Source = VideoPath();


    }
    public async void Init()
    {
        dynamic forecastData = await OnGetForecast(-122.3321, 47.6062);

        LineData1 = GetAirTemp(forecastData);
        LineData2 = new ObservableCollection<ChartDataModel>
        {
            new ChartDataModel("Now", 56),
            new ChartDataModel("+1", 44),
            new ChartDataModel("+2", 48),
            new ChartDataModel("+3", 50),
            new ChartDataModel("+4", 66),
            new ChartDataModel("+5", 78)
        };

        LineData3 = new ObservableCollection<ChartDataModel>
        {
            new ChartDataModel("Now", 0),
            new ChartDataModel("+1", 0),
            new ChartDataModel("+2", 0),
            new ChartDataModel("+3", 0),
            new ChartDataModel("+4", 0),
            new ChartDataModel("+5", 0)
        };

        AirSeries.ItemsSource = LineData1;
        //WSSeries.ItemsSource = LineData2;
        //WDSeries.ItemsSource = LineData3;
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
    public ObservableCollection<ChartDataModel> GetAirTemp(dynamic dynamic)
    {
        ObservableCollection<double> airTemps = new ObservableCollection<double>();
        foreach (var period in dynamic.properties.periods.Take(5))
        {
            double temperature = period.temperature;
            airTemps.Add(temperature);
        }

        return new ObservableCollection<ChartDataModel>
        {
            new ChartDataModel("Now", airTemps[0]),
            new ChartDataModel("+1", airTemps[1]),
            new ChartDataModel("+2", airTemps[2]),
            new ChartDataModel("+3", airTemps[3]),
            new ChartDataModel("+4", airTemps[4])
        };
    }
    public HtmlWebViewSource VideoPath()
    {
        HtmlWebViewSource hal = new HtmlWebViewSource();
        string iframeHtml = $@"
                <html>
                    <body>
                        <iframe width='370' height='250' src='https://www.youtube.com/embed/XpC7TdaWKpg?autoplay=1&showinfo=0&controls=0' frameborder='0' allow='autoplay'></iframe>
                    </body>
                </html>";
        hal.Html = iframeHtml;
        return hal;
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
