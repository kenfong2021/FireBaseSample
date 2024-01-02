using FireBaseAuth.ViewModels;

namespace FireBaseAuth.Pages;

public partial class PasswordResetPage : ContentPage
{
	public PasswordResetPage(AuthViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }
}