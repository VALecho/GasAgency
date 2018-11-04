using GasAgency.Helpers;
using GasAgency.Repository;
using GasAgency.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GasAgency
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "http://localhost:44383";
        public static bool UseMockDataStore = true;

        public static DatabaseHelper Database { get; set; }

        public App()
        {
            InitializeComponent();
            if(Database == null)
            {
                var dbPath = DependencyService.Get<ILocalDatabaseHelper>().GetLocalFilePath("GasAgency.db3");
                Database = new DatabaseHelper(dbPath);
            }
            var navigationPage = new NavigationPage(new Dashboard())
            {
                BarBackgroundColor = Color.FromHex("#396ec3")
            };
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
