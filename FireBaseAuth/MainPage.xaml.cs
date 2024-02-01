using FireBaseAuth.Pages;
using FireBaseAuth.Services;

namespace FireBaseAuth
{
    public partial class MainPage : ContentPage
    {
        private readonly IPhoneAuthenticationService _phoneAuthenticationService;
        public MainPage(IPhoneAuthenticationService phoneAuthenticationService)
        {
            InitializeComponent();
            _phoneAuthenticationService = phoneAuthenticationService;
        }

        async void OnOpenWebButtonClicked(System.Object sender, System.EventArgs e)
        {
            await Browser.OpenAsync("https://www.devexpress.com/maui/");
        }


        async void UserRoute(object sender, EventArgs e)
        {
            await AppShell.Current.GoToAsync(nameof(UserPage));
        }
    }
}