namespace ReadyWaters.Views;

public partial class LVPage : ContentPage
{
    int count = 1;
	public LVPage()
	{
		InitializeComponent();
	}
    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
        string url = $"https://www.glerl.noaa.gov/res/glcfs/ont/frames//uv_{value}.png?1699262749509";
        Chart1.Source = url;
    }
}