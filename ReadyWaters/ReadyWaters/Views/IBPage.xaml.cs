using ImageMagick;
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
        OnGetForecast(43.1790113, -77.5714571);
        //Init();
        GetDateTimeStamp();
        //Webcam.Source = VideoPath();


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
        client.DefaultRequestHeaders.Add("User-Agent", "WaterReady");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        HttpResponseMessage response = await client.GetAsync(url);
        //response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<dynamic>(content);
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

    public void GetDateTimeStamp()
    {
        
        DateTimeNow = DateTime.Now;
        string dateTimeNowToString = (DateTimeNow).ToString("h:mm tt");
        string year = DateTimeNow.Year.ToString();
        string month = DateTimeNow.ToString("MM");
        string day = DateTimeNow.ToString("dd");
        string hour = ((DateTimeNow.Hour) - 1).ToString();
        string minute = "56";//DateTimeNow.ToString();IF THE CAMERA SOURCE GETS OUT OF SYNC, THERE COULD BE A PROBLEM AND THIS VALUE "56", REPRESENTING MINUTES IN THE URL, MAY HAVE TO CHANGE

        gRUrl = $"https://cameras-cam.cdn.weatherbug.net/RCGLH/{year}/{month}/{day}/{month}{day}{year}{hour}{minute}_l.jpg";
        //if((DateTimeNow.Hour - 1) >= 13)
        //WCTimestamp.Text = $"{DateTime.Now.Hour - 13}:{minute}";
        //else
        //WCTimestamp.Text = $"{DateTime.Now.Hour - 1}:{minute}";
        WCTimestamp.Text = dateTimeNowToString;
        WebcamImage.Source = gRUrl;


    }

}
