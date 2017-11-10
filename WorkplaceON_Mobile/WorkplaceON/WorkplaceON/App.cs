using WorkplaceON.Modules.Services;
using Xamarin.Forms;
using WorkplaceON.Data;
using Plugin.FirebasePushNotification;

namespace WorkplaceON
{

    public class App : Application
    {

        public static WorkplaceONRestManager WPORestManager { get; private set; }
        static UserDatabaseController userDatabase;
        public App()
        {
            WPORestManager = new WorkplaceONRestManager(new RestService());
            if (Application.Current.Properties.ContainsKey("isFirstTime"))
            {
                MainPage = new NavigationPage(new WelcomeBackScreen());
            }
            else {
                MainPage = new NavigationPage(new StartScreen());
            }
            
        }
        public static UserDatabaseController userDatabaseUtil
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }
        protected override void OnStart()
        {

            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"Received new token::: {p.Token}");
                Application.Current.Properties["fcmRegToken"] = p.Token;
            };
            if (Application.Current.Properties.ContainsKey("fcmRegToken"))
            {
                var regToken = Application.Current.Properties["fcmRegToken"] as string;
                System.Diagnostics.Debug.WriteLine($"Stored token:::: {regToken}");
            }
        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}