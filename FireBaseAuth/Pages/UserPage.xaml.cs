using CommunityToolkit.Mvvm.Input;
using DevExpress.XtraEditors.Filtering;
using Firebase.Database;
using Firebase.Database.Query;
using FireBaseAuth.Models;
using FireBaseAuth.ViewModels;
using System.Collections.ObjectModel;
 

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

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var label = (Label)sender;
        var source = (NoteModel)label.BindingContext;
        var vm = (AuthViewModel)this.BindingContext;
        vm.UpdateNote(source);
        TitleEntry.Text = label.Text;
    }

}