using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.VisualElements;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ReadyWaters.ViewModels
{
    public class IBViewModel : BaseViewModel
    {
        public ObservableCollection<ChartDataModel> LineData1 { get; set; }

        public ObservableCollection<ChartDataModel> LineData2 { get; set; }

        public ObservableCollection<ChartDataModel> LineData3 { get; set; }

        public IBViewModel()
        {

            LineData1 = GetAirTemp(OnGetForecast(-122.3321, 47.6062));

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
        }
        public async Task<dynamic> OnGetForecast(double lon, double lat)
        {
            dynamic query = await FetchURLToJson($"https://api.weather.gov/points/{lon},{lat}");
            return query.properties.forecastHourly;

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
    }
}
