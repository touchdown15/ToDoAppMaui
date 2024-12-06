using TODOApp.Views.Home;

namespace TODOApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }
    }
}
