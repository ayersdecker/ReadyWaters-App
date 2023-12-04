using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using System.Timers;
using System.Collections.ObjectModel;
using ReadyWaters.ViewModels;
using Microcharts;
using SkiaSharp;

namespace ReadyWaters.Views;

public partial class GRPage : ContentPage
{
    public DateTime DateTimeNow { get; set; }

    public GRPage()
	{
		InitializeComponent();
        InitializeChartsAsync();


    }
    private async void InitializeChartsAsync()
    {
        try
        {
            var forecastStatus = await OnGetForecast(43.1790113, -77.5714571);
            GetChartData(forecastStatus);
            GetDateTimeStamp();
        }
        catch (Exception ex)
        {
        }
    }
    private void GetChartData(dynamic data)
    {

        float num0 = data.properties.periods[0].temperature;
        float num1 = data.properties.periods[1].temperature;
        float num2 = data.properties.periods[2].temperature;
        float num3 = data.properties.periods[3].temperature;
        float num4 = data.properties.periods[4].temperature;
        float num5 = data.properties.periods[5].temperature;
        float num6 = data.properties.periods[6].temperature;
        float num7 = data.properties.periods[7].temperature;

        string windSpeedString10 = data.properties.periods[0].windSpeed;
        string windSpeedString11 = data.properties.periods[1].windSpeed;
        string windSpeedString12 = data.properties.periods[2].windSpeed;
        string windSpeedString13 = data.properties.periods[3].windSpeed;
        string windSpeedString14 = data.properties.periods[4].windSpeed;
        string windSpeedString15 = data.properties.periods[5].windSpeed;
        string windSpeedString16 = data.properties.periods[6].windSpeed;
        string windSpeedString17 = data.properties.periods[7].windSpeed;

        string numericPart10 = new string(windSpeedString10.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString10.IndexOf('.') == windSpeedString10.LastIndexOf('.'))).ToArray());
        string numericPart11 = new string(windSpeedString11.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString11.IndexOf('.') == windSpeedString11.LastIndexOf('.'))).ToArray());
        string numericPart12 = new string(windSpeedString12.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString12.IndexOf('.') == windSpeedString12.LastIndexOf('.'))).ToArray());
        string numericPart13 = new string(windSpeedString13.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString13.IndexOf('.') == windSpeedString13.LastIndexOf('.'))).ToArray());
        string numericPart14 = new string(windSpeedString14.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString14.IndexOf('.') == windSpeedString14.LastIndexOf('.'))).ToArray());
        string numericPart15 = new string(windSpeedString15.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString15.IndexOf('.') == windSpeedString15.LastIndexOf('.'))).ToArray());
        string numericPart16 = new string(windSpeedString16.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString16.IndexOf('.') == windSpeedString16.LastIndexOf('.'))).ToArray());
        string numericPart17 = new string(windSpeedString17.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString17.IndexOf('.') == windSpeedString17.LastIndexOf('.'))).ToArray());


        bool num10Test = float.TryParse(numericPart10, out float num10);
        bool num11Test = float.TryParse(numericPart11, out float num11);
        bool num12Test = float.TryParse(numericPart12, out float num12);
        bool num13Test = float.TryParse(numericPart13, out float num13);
        bool num14Test = float.TryParse(numericPart14, out float num14);
        bool num15Test = float.TryParse(numericPart15, out float num15);
        bool num16Test = float.TryParse(numericPart16, out float num16);
        bool num17Test = float.TryParse(numericPart17, out float num17);

        string windDirectionString20 = data.properties.periods[0].windDirection;
        string windDirectionString21 = data.properties.periods[1].windDirection;
        string windDirectionString22 = data.properties.periods[2].windDirection;
        string windDirectionString23 = data.properties.periods[3].windDirection;
        string windDirectionString24 = data.properties.periods[4].windDirection;
        string windDirectionString25 = data.properties.periods[5].windDirection;
        string windDirectionString26 = data.properties.periods[6].windDirection;
        string windDirectionString27 = data.properties.periods[7].windDirection;


        var entries1 = new[]
        {
            new ChartEntry(num0)
            {
                Label = "Now",
                ValueLabel = $"{num0}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#266489")
            },
            new ChartEntry(num1)
            {
                Label = "+1hr",
                ValueLabel = $"{num1}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#68B9C0")
            },
            new ChartEntry(num2)
            {
                Label = "+2hr",
                ValueLabel = $"{num2}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num3)
            {
                Label = "+3hr",
                ValueLabel = $"{num3}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num4)
            {
                Label = "+4hr",
                ValueLabel = $"{num4}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num5)
            {
                Label = "+5hr",
                ValueLabel = $"{num5}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num6)
            {
                Label = "+6hr",
                ValueLabel = $"{num6}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num7)
            {
                Label = "+7hr",
                ValueLabel = $"{num7}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            }
        };

        var entries2 = new[]
        {
            new ChartEntry(num10)
            {
                Label = "Now",
                ValueLabel = $"{num10}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#266489")
            },
            new ChartEntry(num11)
            {
                Label = "+1hr",
                ValueLabel = $"{num11}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#68B9C0")
            },
            new ChartEntry(num12)
            {
                Label = "+2hr",
                ValueLabel = $"{num12}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num13)
            {
                Label = "+3hr",
                ValueLabel = $"{num13}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num14)
            {
                Label = "+4hr",
                ValueLabel = $"{num14}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num15)
            {
                Label = "+5hr",
                ValueLabel = $"{num15}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num16)
            {
                Label = "+6hr",
                ValueLabel = $"{num16}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num17)
            {
                Label = "+7hr",
                ValueLabel = $"{num17}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            }
        };



        chartView1.Chart = new LineChart() { Entries = entries1, ValueLabelTextSize = 30, ValueLabelOrientation = Orientation.Horizontal, LabelColor = SKColor.Parse("#FFFFFF"), PointSize = 10, LabelTextSize = 30, BackgroundColor = SKColor.Parse("#201E1F") };
        chartView2.Chart = new LineChart() { Entries = entries2, ValueLabelTextSize = 30, ValueLabelOrientation = Orientation.Horizontal, LabelColor = SKColor.Parse("#FFFFFF"), PointSize = 10, LabelTextSize = 30, BackgroundColor = SKColor.Parse("#201E1F") };
        Dir0Label.Text = windDirectionString20;
        Dir1Label.Text = windDirectionString21;
        Dir2Label.Text = windDirectionString22;
        Dir3Label.Text = windDirectionString23;
        Dir4Label.Text = windDirectionString24;
        Dir5Label.Text = windDirectionString25;
        Dir6Label.Text = windDirectionString26;
        Dir7Label.Text = windDirectionString27;
    }

    public async Task<dynamic> OnGetForecast(double lon, double lat)
    {
        dynamic query = await FetchURLToJson($"https://api.weather.gov/points/{lon},{lat}");
        string forecastUrl = query.properties.forecast;
        dynamic forecast = await FetchURLToJson(forecastUrl);

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

    public void GetDateTimeStamp()
    {

        DateTimeNow = DateTime.Now;
        string dateTimeNowToString = (DateTimeNow).ToString("h:mm tt");
        string year = DateTimeNow.Year.ToString();
        string month = DateTimeNow.ToString("MM");
        string day = DateTimeNow.ToString("dd");
        string hour = ((DateTimeNow.Hour) - 1).ToString();
        string ampm = (DateTimeNow.Hour - 1) < 12 ? "am" : "pm";
        string minute = "56";//DateTimeNow.ToString();IF THE CAMERA SOURCE GETS OUT OF SYNC, THERE COULD BE A PROBLEM AND THIS VALUE "56", REPRESENTING MINUTES IN THE URL, MAY HAVE TO CHANGE
        WCTimestamp.Text = hour + ":" + minute + " " + ampm;
        if (hour.Length == 1) { hour = "0" + hour; }

        WebcamImage.Source = $"https://cameras-cam.cdn.weatherbug.net/RCGLH/{year}/{month}/{day}/{month}{day}{year}{hour}{minute}_l.jpg";
    }
}