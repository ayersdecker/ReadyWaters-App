<<<<<<< HEAD

=======
>>>>>>> fd555e51504a5f072c97d24be546d8f4d311ba5a

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
        await Browser.Default.OpenAsync("https://www.noaa.gov" );
    }
    private async void WeatherBugButton_Clicked(object sender, EventArgs e)
    {       
        await Browser.Default.OpenAsync("https://www.weatherbug.com");
    }
    private async void GLERLButton_Clicked(object sender, EventArgs e)
    {        
        await Browser.Default.OpenAsync("https://www.glerl.noaa.gov/res/glcfs/ncast.php?lake=ont");
    }
    
}