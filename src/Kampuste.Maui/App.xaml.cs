namespace Kampuste.Maui
{
    public partial class App : Application
    {
        public const string CallbackUri = "bookstore://";
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
