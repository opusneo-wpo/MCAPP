using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace WorkplaceON.Modules.MainApp.Views
{
    public partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        protected override void OnCurrentPageChanged()
        {
            Title = CurrentPage?.Title;
            base.OnCurrentPageChanged();        
        }
    }
}