namespace ReadyWaters
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Current.UserAppTheme = AppTheme.Dark;
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjgxMDgzN0AzMjMzMmUzMDJlMzBUQmd4RUVFY3ErVjhpbWVybGFnNy9xb3RoVFRCQ0dhVm1qQnZmM2RLQmlrPQ==");
            MainPage = new AppShell();
        }
    }
}