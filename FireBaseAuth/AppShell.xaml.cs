using FireBaseAuth.Pages;

namespace FireBaseAuth
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // register
            Routing.RegisterRoute(nameof(AuthPage), typeof(AuthPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(PasswordResetPage), typeof(PasswordResetPage));
            Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));
        }
    }
}
