using System.ComponentModel.Design;

namespace ReadyWaters.Views;

public partial class LVPage : ContentPage
{
    // Chart Sources
    public string SurfaceCurrents = "https://www.glerl.noaa.gov/res/glcfs/ont/frames//uv_{0}.png";
    public string SurfaceTemps = "https://www.glerl.noaa.gov/res/glcfs/ont/frames//temp_{0}.png";
    public string WaterLevels = "https://www.glerl.noaa.gov/res/glcfs/ont/frames//zeta_{0}.png";

    // Selected Chart Source
    public string SelectedChart1 { get; set; }
    public string SelectedChart2 { get; set; }

    // Selection Options
    public List<string> ChartOptions = new List<string> { "Surface Currents", "Surface Temperatures", "Water Levels" };

    public string actualForecastHour = "";

    public LVPage()
    {
        InitializeComponent();
        ChartInitialization();

    }

    // Method to initialize the charts
    private void ChartInitialization()
    {

        // Current Time
        DateTime currentTime = DateTime.Now;
        int currentHour = currentTime.Hour; 

        // Set the default chart sources
        SelectedChart1 = SurfaceCurrents;
        SelectedChart2 = SurfaceTemps;

        // Set the default chart options
        Chart1Select.ItemsSource = ChartOptions;
        Chart2Select.ItemsSource = ChartOptions;

        // Set the default chart selection (FOR PLACEHOLDER TEXT)
        Chart1Select.SelectedIndex = 0;
        Chart2Select.SelectedIndex = 1;

        // Source the default charts
        Chart1.Source = String.Format(SelectedChart1, (currentHour/3) + 49);
        Chart2.Source = String.Format(SelectedChart2, (currentHour/3) + 49);

        // Set the default chart labels
        Chart1Label.Text = $"{Chart1Select.SelectedItem} ({actualForecastHour} forecast)";
        Chart2Label.Text = $"{Chart2Select.SelectedItem} ({actualForecastHour} forecast)";
    }

    // Method to handle the chart selection event
    private void ChartSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;


        if (ReferenceEquals(picker, Chart1Select))
        {
            if (selectedIndex != -1)
            {
                if (selectedIndex == 0) { SelectedChart1 = SurfaceCurrents; }
                if (selectedIndex == 1) { SelectedChart1 = SurfaceTemps; }
                if (selectedIndex == 2) { SelectedChart1 = WaterLevels; }
                Chart1.Source = string.Format(SelectedChart1, 49 + Slider.Value);
            }
        }

        else if (ReferenceEquals(picker, Chart2Select))
        {
            if (selectedIndex != -1)
            {
                if (selectedIndex == 0) { SelectedChart2 = SurfaceCurrents; }
                if (selectedIndex == 1) { SelectedChart2 = SurfaceTemps; }
                if (selectedIndex == 2) { SelectedChart2 = WaterLevels; }
                Chart2.Source = string.Format(SelectedChart2, 49 + Slider.Value);
            }
        }
    }

    private void ChartLabelRefresh()
    {
        DateTime initialTime = DateTime.Now;
        string initialTimeToString = (initialTime).ToString("h:mm tt");
        string amPm = initialTime.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);
        //string hour = initialTime.ToString("h", System.Globalization.CultureInfo.InvariantCulture);
        DateTime initialtimeParsed = DateTime.Parse(initialTimeToString);
        int hourParsed = initialtimeParsed.Hour;
        int initialHour = initialTime.Hour;
        


        /*I was trying to make the label for the chart update/respond properly according to the selection on the slider so that
         it would say what forecast it is displaying; meaning the midnight forecast, the 3 o'clock forecast
        6, or 9. Currently it is just displaying the current time as if it is the current forecast of that hour. This needs
        to be fixed.*/
        actualForecastHour="";

        //if ((initialHour >= 0 && initialHour < 3) || initialHour == 24) {actualForecastHour = "12"; }
        //if (initialHour >= 3 && initialHour < 6 || initialHour >= 15 && initialHour < 18) {actualForecastHour = "3"; }
        //if (initialHour >= 6 && initialHour < 9 || initialHour >= 18 && initialHour < 21) {actualForecastHour = "6"; }
        //if (initialHour >= 9 && initialHour < 12 || initialHour >= 21 && initialHour < 24) {actualForecastHour = "9"; }
        

        double num = Slider.Value;

        if (num == 0)
        {
            
            //I tried in this first chart label to have it respond correctly
            Chart1Label.Text = $"{Chart1Select.SelectedItem} ({actualForecastHour} {amPm}) forecast";

           //I initially just used the current time to display on this second chart label
           Chart2Label.Text = $"{Chart2Select.SelectedItem}: ({actualForecastHour} {amPm}) forecast)";        

            return;
        }
        else if(num == 3) 
        {
            initialHour = initialTime.Hour + 3;
            if ((initialHour >= 0 && initialHour < 3) || initialHour > 21) { actualForecastHour = "12"; }
            if (initialHour >= 3 && initialHour < 6 || initialHour >= 12 && initialHour < 15) { actualForecastHour = "3"; }
            if (initialHour >= 6 && initialHour < 9 || initialHour >= 15 && initialHour < 18) { actualForecastHour = "6"; }
            if (initialHour >= 9 && initialHour < 12 || initialHour >= 18 && initialHour < 21) { actualForecastHour = "9"; }

            //int actualForecastHourConverted = int.Parse(actualForecastHour);
            Chart1Label.Text = $"{Chart1Select.SelectedItem}: ({actualForecastHour} {amPm} forecast)";
            Chart2Label.Text = $"{Chart2Select.SelectedItem}: {num * 3} hours from now";
            return;
        }
        else if (num == 6)
        {
            initialHour = initialHour + 6;
            if ((initialHour >= 0 && initialHour < 3) || initialHour > 21 && initialHour < 27) { actualForecastHour = "12"; }
            if (initialHour >= 3 && initialHour < 6 || initialHour >= 12 && initialHour < 15 || initialHour >= 27 && initialHour <30) { actualForecastHour = "3"; }
            if (initialHour >= 6 && initialHour < 9 || initialHour >= 15 && initialHour < 18 || initialHour >= 30 && initialHour <33) { actualForecastHour = "6"; }
            if (initialHour >= 9 && initialHour < 12 || initialHour >= 18 && initialHour < 21) { actualForecastHour = "9"; }

            //int actualForecastHourConverted = int.Parse(actualForecastHour);
            Chart1Label.Text = $"{Chart1Select.SelectedItem}: ({actualForecastHour} {amPm} forecast)";
            Chart2Label.Text = $"{Chart2Select.SelectedItem}: {num * 3} hours from now";
        }
        else if (num == 9)
        {
            initialHour = initialHour + 9;
            if ((initialHour >= 0 && initialHour < 3) || initialHour > 21) { actualForecastHour = "12"; }
            if (initialHour >= 3 && initialHour < 6 || initialHour >= 12 && initialHour < 15) { actualForecastHour = "3"; }
            if (initialHour >= 6 && initialHour < 9 || initialHour >= 15 && initialHour < 18) { actualForecastHour = "6"; }
            if (initialHour >= 9 && initialHour < 12 || initialHour >= 18 && initialHour < 21) { actualForecastHour = "9"; }

            //int actualForecastHourConverted = int.Parse(actualForecastHour);
            Chart1Label.Text = $"{Chart1Select.SelectedItem}: ({actualForecastHour} {amPm} forecast)";
            Chart2Label.Text = $"{Chart2Select.SelectedItem}: ({actualForecastHour} {amPm} forecast)";
        }
        else if (num == 12)
        {
            initialHour = initialHour + 12;
            if ((initialHour >= 0 && initialHour < 3) || initialHour > 21) { actualForecastHour = "12"; }
            if (initialHour >= 3 && initialHour < 6 || initialHour >= 12 && initialHour < 15) { actualForecastHour = "3"; }
            if (initialHour >= 6 && initialHour < 9 || initialHour >= 15 && initialHour < 18) { actualForecastHour = "6"; }
            if (initialHour >= 9 && initialHour < 12 || initialHour >= 18 && initialHour < 21) { actualForecastHour = "9"; }

            //int actualForecastHourConverted = int.Parse(actualForecastHour);
            Chart1Label.Text = $"{Chart1Select.SelectedItem}: ({actualForecastHour} {amPm} forecast)";
            Chart2Label.Text = $"{Chart2Select.SelectedItem}: ({actualForecastHour} {amPm} forecast)";
        }
    }

    // Method to handle the slider value change event
    private void Slider_ValueChanged(object sender, Syncfusion.Maui.Sliders.SliderValueChangedEventArgs e)
    {
        
        DateTime currentTime = DateTime.Now;
        int currentHour = currentTime.Hour;

        double num = Slider.Value / 3;

        // Refesh the chart labels
        ChartLabelRefresh();

        // Perform haptic feedback
        HapticFeedback.Default.Perform(HapticFeedbackType.Click);

        // Update chart sources
        Chart1.Source = String.Format(SelectedChart1, (num + (currentHour/3)+49));
        Chart2.Source = String.Format(SelectedChart2, (num + (currentHour/3)+49));
    }
}