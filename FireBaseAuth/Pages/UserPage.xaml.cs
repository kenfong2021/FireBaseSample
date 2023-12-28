namespace FireBaseAuth.Pages;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
	}

    private async void AuthRoute(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(AuthPage));
    }
}