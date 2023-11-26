using Microsoft.Maui.Platform;

namespace ReadyWaters.Views;

public partial class LVPage : ContentPage
{


    public LVPage()
	{
        InitializeComponent();
    }

   



    private void Slider_ValueChanged(object sender, Syncfusion.Maui.Sliders.SliderValueChangedEventArgs e)
    {
        double num = Slider.Value;
        if (num > 0) { Chart1Label.Text = $"UV Index for {num * 3} hours from now"; Chart2Label.Text = $"Water Temperature for {num * 3 hours from now";}
        if (num == 0) { Chart1Label.Text = $"UV Index for now"; Chart2Label.Text = $"Water Temperature for now"; }
        HapticFeedback.Default.Perform(HapticFeedbackType.Click);
        Chart1.Source = $"https://www.glerl.noaa.gov/res/glcfs/ont/frames//uv_{num + 49}.png?1699262749509";
        Chart2.Source = $"https://www.glerl.noaa.gov/res/glcfs/ont/frames//temp_{num + 49}.png";
          
    }
}