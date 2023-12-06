using ImageMagick;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using Newtonsoft.Json;
using ReadyWaters.ViewModels;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Globalization;
using Microcharts;

namespace ReadyWaters.Views;

public partial class IBPage : ContentPage
{
    public DateTime DateTimeNow { get; set; }
    public ObservableCollection<ChartDataModel> LineData1 { get; set; } = new ObservableCollection<ChartDataModel>();
    public ObservableCollection<ChartDataModel> LineData2 { get; set; } = new ObservableCollection<ChartDataModel>();
    public ObservableCollection<ChartDataModel> LineData3 { get; set; } = new ObservableCollection<ChartDataModel>();

    public IBPage()
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
        float num8 = data.properties.periods[8].temperature;
        float num9 = data.properties.periods[9].temperature;
        float num10 = data.properties.periods[10].temperature;
        float num11 = data.properties.periods[11].temperature;


        string windSpeedString10 = data.properties.periods[0].windSpeed;
        string windSpeedString11 = data.properties.periods[1].windSpeed;
        string windSpeedString12 = data.properties.periods[2].windSpeed;
        string windSpeedString13 = data.properties.periods[3].windSpeed;
        string windSpeedString14 = data.properties.periods[4].windSpeed;
        string windSpeedString15 = data.properties.periods[5].windSpeed;
        string windSpeedString16 = data.properties.periods[6].windSpeed;
        string windSpeedString17 = data.properties.periods[7].windSpeed;
        string windSpeedString18 = data.properties.periods[8].windSpeed;
        string windSpeedString19 = data.properties.periods[9].windSpeed;
        string windSpeedString110 = data.properties.periods[10].windSpeed;
        string windSpeedString111= data.properties.periods[11].windSpeed;

        string numericPart10 = new string(windSpeedString10.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString10.IndexOf('.') == windSpeedString10.LastIndexOf('.'))).ToArray());
        string numericPart11 = new string(windSpeedString11.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString11.IndexOf('.') == windSpeedString11.LastIndexOf('.'))).ToArray());
        string numericPart12 = new string(windSpeedString12.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString12.IndexOf('.') == windSpeedString12.LastIndexOf('.'))).ToArray());
        string numericPart13 = new string(windSpeedString13.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString13.IndexOf('.') == windSpeedString13.LastIndexOf('.'))).ToArray());
        string numericPart14 = new string(windSpeedString14.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString14.IndexOf('.') == windSpeedString14.LastIndexOf('.'))).ToArray());
        string numericPart15 = new string(windSpeedString15.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString15.IndexOf('.') == windSpeedString15.LastIndexOf('.'))).ToArray());
        string numericPart16 = new string(windSpeedString16.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString16.IndexOf('.') == windSpeedString16.LastIndexOf('.'))).ToArray());
        string numericPart17 = new string(windSpeedString17.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString17.IndexOf('.') == windSpeedString17.LastIndexOf('.'))).ToArray());
        string numericPart18 = new string(windSpeedString18.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString18.IndexOf('.') == windSpeedString18.LastIndexOf('.'))).ToArray());
        string numericPart19 = new string(windSpeedString19.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString19.IndexOf('.') == windSpeedString19.LastIndexOf('.'))).ToArray());
        string numericPart110 = new string(windSpeedString110.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString110.IndexOf('.') == windSpeedString110.LastIndexOf('.'))).ToArray());
        string numericPart111 = new string(windSpeedString111.TakeWhile(c => char.IsDigit(c) || (c == '.' && windSpeedString111.IndexOf('.') == windSpeedString111.LastIndexOf('.'))).ToArray());

        bool num10Test = float.TryParse(numericPart10, out float numOut10);
        bool num11Test = float.TryParse(numericPart11, out float numOut11);
        bool num12Test = float.TryParse(numericPart12, out float numOut12);
        bool num13Test = float.TryParse(numericPart13, out float numOut13);
        bool num14Test = float.TryParse(numericPart14, out float numOut14);
        bool num15Test = float.TryParse(numericPart15, out float numOut15);
        bool num16Test = float.TryParse(numericPart16, out float numOut16);
        bool num17Test = float.TryParse(numericPart17, out float numOut17);
        bool num18Test = float.TryParse(numericPart18, out float numOut18);
        bool num19Test = float.TryParse(numericPart19, out float numOut19);
        bool num110Test = float.TryParse(numericPart110, out float numOut110);
        bool num111Test = float.TryParse(numericPart111, out float numOut111);

        string windDirectionString20 = data.properties.periods[0].windDirection;
        string windDirectionString21 = data.properties.periods[1].windDirection;
        string windDirectionString22 = data.properties.periods[2].windDirection;
        string windDirectionString23 = data.properties.periods[3].windDirection;
        string windDirectionString24 = data.properties.periods[4].windDirection;
        string windDirectionString25 = data.properties.periods[5].windDirection;
        string windDirectionString26 = data.properties.periods[6].windDirection;
        string windDirectionString27 = data.properties.periods[7].windDirection;
        string windDirectionString28 = data.properties.periods[8].windDirection;
        string windDirectionString29 = data.properties.periods[9].windDirection;
        string windDirectionString210 = data.properties.periods[10].windDirection;
        string windDirectionString211 = data.properties.periods[11].windDirection;


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
            },

            new ChartEntry(num8)
            {
                Label = "+8hr",
                ValueLabel = $"{num8}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num9)
            {
                Label = "+9hr",
                ValueLabel = $"{num9}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num10)
            {
                Label = "+10hr",
                ValueLabel = $"{num10}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(num11)
            {
                Label = "+11hr",
                ValueLabel = $"{num11}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            }
        };

        var entries2 = new[]
        {
            new ChartEntry(numOut10)
            {
                Label = "Now",
                ValueLabel = $"{numOut10}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#266489")
            },
            new ChartEntry(numOut11)
            {
                Label = "+1hr",
                ValueLabel = $"{numOut11}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#68B9C0")
            },
            new ChartEntry(numOut12)
            {
                Label = "+2hr",
                ValueLabel = $"{numOut12}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(numOut13)
            {
                Label = "+3hr",
                ValueLabel = $"{numOut13}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(numOut14)
            {
                Label = "+4hr",
                ValueLabel = $"{numOut14}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(numOut15)
            {
                Label = "+5hr",
                ValueLabel = $"{numOut15}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(numOut16)
            {
                Label = "+6hr",
                ValueLabel = $"{numOut16}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(numOut17)
            {
                Label = "+7hr",
                ValueLabel = $"{numOut17}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },

            new ChartEntry(numOut18)
            {
                Label = "+8hr",
                ValueLabel = $"{numOut18}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(numOut19)
            {
                Label = "+9hr",
                ValueLabel = $"{numOut19}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(numOut110)
            {
                Label = "+10hr",
                ValueLabel = $"{numOut110}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            },
            new ChartEntry(numOut111)
            {
                Label = "+11hr",
                ValueLabel = $"{numOut111}",
                ValueLabelColor = SKColor.Parse("#FFFFFF"),
                Color = SKColor.Parse("#90D585")
            }
        };



        chartView1.Chart = new LineChart() { Entries = entries1, ValueLabelTextSize = 30,ValueLabelOrientation = Orientation.Horizontal, LabelColor = SKColor.Parse("#FFFFFF"), PointSize = 10, LabelTextSize = 30, BackgroundColor = SKColor.Parse("#201E1F") };
        chartView2.Chart = new LineChart() { Entries = entries2, ValueLabelTextSize = 30, ValueLabelOrientation = Orientation.Horizontal, LabelColor = SKColor.Parse("#FFFFFF"), PointSize = 10, LabelTextSize = 30, BackgroundColor = SKColor.Parse("#201E1F") };
        Dir0Label.Text = windDirectionString20;
        Dir1Label.Text = windDirectionString21;
        Dir2Label.Text = windDirectionString22;
        Dir3Label.Text = windDirectionString23;
        Dir4Label.Text = windDirectionString24;
        Dir5Label.Text = windDirectionString25;
        Dir6Label.Text = windDirectionString26;
        Dir7Label.Text = windDirectionString27;
        Dir8Label.Text = windDirectionString28;
        Dir9Label.Text = windDirectionString29;
        Dir10Label.Text = windDirectionString210;
        Dir11Label.Text = windDirectionString211;
    }

    public async Task<dynamic> OnGetForecast(double lon, double lat)
    {
        dynamic query = await FetchURLToJson($"https://api.weather.gov/points/{lon},{lat}");
        string forecastUrl = query.properties.forecastHourly;
        dynamic forecast = await FetchURLToJson(forecastUrl);

        //string forecastText = forecast.properties.periods[0].detailedForecast;
        //AirTempField.Text = forecast.properties.periods[0].temperature + " F";
        //string humidity = forecast.properties.periods[0].relativeHumidity + "%";
        //WindVelocityField.Text = forecast.properties.periods[0].windSpeed;
        //WindDirectionField.Text = forecast.properties.periods[0].windDirection;

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
                        <iframe position='absolute' width='400' height='100' src='https://www.youtube.com/embed/XpC7TdaWKpg?autoplay=1&showinfo=0&controls=0' frameborder='0' allow='autoplay'></iframe>
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
        string ampm = (DateTimeNow.Hour - 1) < 12 ? "am" : "pm";
        string minute = "56";//DateTimeNow.ToString();IF THE CAMERA SOURCE GETS OUT OF SYNC, THERE COULD BE A PROBLEM AND THIS VALUE "56", REPRESENTING MINUTES IN THE URL, MAY HAVE TO CHANGE
        string newHour = hour;
        if (int.Parse(hour) > 12) { newHour = (int.Parse(hour) - 12).ToString(); }

        WCTimestamp.Text = newHour + ":" + minute + " " + ampm;
        if (hour.Length == 1) { hour = "0" + hour; }

        // = $"https://cameras-cam.cdn.weatherbug.net/RCGLH/{year}/{month}/{day}/{month}{day}{year}{hour}{minute}_l.jpg";
        //if((DateTimeNow.Hour - 1) >= 13)
        //WCTimestamp.Text = $"{DateTime.Now.Hour - 13}:{minute}";
        //else
        //WCTimestamp.Text = $"{DateTime.Now.Hour - 1}:{minute}";
        //WebcamImage.Source = gRUrl;


    }

}
