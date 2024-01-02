using FireBaseAuth.ViewModels;

namespace FireBaseAuth.Pages;

public partial class UserPage : ContentPage
{
	public UserPage(AuthViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }

    private async void AuthRoute(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(AuthPage));
    }
}