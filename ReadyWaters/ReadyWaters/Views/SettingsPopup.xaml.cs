

namespace ReadyWaters.Views;

public partial class SettingsPopup
{
	public SettingsPopup()
	{
		InitializeComponent();
	}
    
    private async void BayCreekButton_Clicked(object sender, EventArgs e)
    {        
        await Browser.Default.OpenAsync("https://www.baycreek.com");
    }
    private async void NOAAButton_Clicked(object sender, EventArgs e)
    {        
        await Browser.Default.OpenAsync("https://forecast.weather.gov/MapClick.php?CityName=Rochester&state=NY&site=BUF&lat=43.1687&lon=-77.6158");
    }
    private async void GLERLButton_Clicked(object sender, EventArgs e)
    {        
        await Browser.Default.OpenAsync("https://www.glerl.noaa.gov/res/glcfs/ncast.php?lake=ont");
    }
    private async void IWindSurfButton_Clicked(object sender, EventArgs e)
    {
        await Browser.Default.OpenAsync("https://wx.iwindsurf.com/windlist/rochester%20ny");
    }
}