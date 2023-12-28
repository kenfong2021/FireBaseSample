using FireBaseAuth.ViewModels;

namespace FireBaseAuth.Pages;

public partial class AuthPage : ContentPage
{
	public AuthPage(AuthViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }

    private async void RegisterRoute(object sender, TappedEventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(RegisterPage));
    }
}