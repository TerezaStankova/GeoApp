using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamApp
{
    public partial class App : Application
    {

        public static ContactRepository ContactRepo { get; private set; }

        public App(string dbPath)
        {
            InitializeComponent();

            ContactRepo = new ContactRepository(dbPath);

            MainPage = new XamApp.MainPage();
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
