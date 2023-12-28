using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using FireBaseAuth.Model;
using FireBaseAuth.Pages;
using FireBaseAuth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBaseAuth.ViewModels
{
    [QueryProperty(nameof(User), "User")]
    public partial class AuthViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserModel _user = new UserModel();
        private readonly IAuthService _authService;
        private bool _isLogin = false;
        public AuthViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async Task GetUser()
        {
            if (_isLogin)
            {
                User = _authService.GetUser();
            }
            await Shell.Current.DisplayAlert("Please Login", "Login", "Ok");
        }

        [RelayCommand]
        public async Task IsLogin()
        {
            _isLogin = await _authService.IsLogin();
        }

        [RelayCommand]
        public async Task LogoutUser()
        {
            await _authService.LogoutWithEmail();
            _isLogin = await _authService.IsLogin();
            await Shell.Current.DisplayAlert("Status: Logout Success", "Logout Success", "Ok");
        }

        [RelayCommand]
        public async Task LoginUserWithEmailAndPassword()
        {
            var result = await _authService.LoginUserWithEmail(new UserModel
            {
                email = User.email,
                password = User.password,
            });
            if (result)
            {
                await Shell.Current.DisplayAlert("Status: Login Success", "Login Success", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Status: Login Failed", "Login failed", "Ok");
            }
        }

        [RelayCommand]
        public async Task RegisterUserWithEmailAndPassword()
        {
            var result = await _authService.RegisterUserWithEmail(new UserModel
            {
                email = User.email,
                password = User.password,
            });
            if (result)
            {
                await Shell.Current.DisplayAlert("Status: Register Success", "User registed", "Ok");
                await AppShell.Current.GoToAsync(nameof(AuthPage));
            }
            else
            {
                await Shell.Current.DisplayAlert("Status: Register Failed", "Something is failed", "Ok");
            }
        }
    }
}
