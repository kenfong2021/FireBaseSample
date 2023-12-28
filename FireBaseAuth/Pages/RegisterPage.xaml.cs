using FireBaseAuth.ViewModels;

namespace FireBaseAuth.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(AuthViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }
}