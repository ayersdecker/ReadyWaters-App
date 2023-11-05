using Mopups.Services;

namespace ReadyWaters
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            MopupService.Instance.PushAsync(new Views.SettingsPopup(), false);
        }
    }
}