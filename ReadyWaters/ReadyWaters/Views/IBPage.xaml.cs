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
    public IBPage()
    {
        InitializeComponent();
        //OnGetForecast(43.1790113, -77.5714571);
        //Init();
        Webcam.Source = VideoPath();

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
    public HtmlWebViewSource VideoPath()
    {
        HtmlWebViewSource hal = new HtmlWebViewSource();
        string iframeHtml = $@"
                <html>
                    <body>
                        <iframe width='370' height='250' src='https://www.youtube.com/embed/9k_sg8rhsgk?autoplay=1&showinfo=0&controls=0' frameborder='0' allow='autoplay'></iframe>
                    </body>
                </html>";
        hal.Html = iframeHtml;
        return hal;
    }
}