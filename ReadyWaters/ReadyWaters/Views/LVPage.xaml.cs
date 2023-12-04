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
        ChartLabelRefresh();
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
        ChartLabelRefresh();
    }

    private void ChartLabelRefresh()
    {
        DateTime currentTime = DateTime.Now;
        double num = Slider.Value;
        int hourGroup = (currentTime.Hour / 3) * 3;
        string ampm = currentTime.Hour < 12 ? "am" : "pm";
        if (hourGroup + num >= 24)
        {
            hourGroup -= 24;
            ampm = "am";
        }

            if(num == 0)
            {
                Chart1Label.Text = $"  {Chart1Select.SelectedItem}: {hourGroup} {ampm}";
                Chart2Label.Text = $"  {Chart2Select.SelectedItem}: {hourGroup} {ampm}";
            }
            else
            {
                Chart1Label.Text = $"  {Chart1Select.SelectedItem}: {hourGroup + num} {ampm}";
                Chart2Label.Text = $"  {Chart2Select.SelectedItem}: {hourGroup + num} {ampm}";
            }
            return;
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