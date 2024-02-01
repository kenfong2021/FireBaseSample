using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using FireBaseAuth.Models;
using FireBaseAuth.Pages;
using FireBaseAuth.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        [ObservableProperty]
        private bool _isLogin = false;
        [ObservableProperty]
        private string _welcomeMsg = "";
        [ObservableProperty]
        private NoteModel _selectedNote;
        [ObservableProperty]
        private string _inputMode = "Save";
        public ObservableCollection<NoteModel> MyNotes { get; set; } = new ObservableCollection<NoteModel>();
        private FirebaseClient firebaseClient;
 
        public AuthViewModel(IAuthService authService)
        {
            _authService = authService;
            
        }

        public void UpdateNote(NoteModel note)
        {
            SelectedNote = note;
            InputMode = "Update";
        }

        public void FillList()
        {
            var collection = firebaseClient
                .Child("users")
                .Child(_user.Id)
                .AsObservable<NoteModel>()
                .Subscribe((item) =>
                {
                    if (item.Object != null)
                    {
                        //var note = MyNotes.FirstOrDefault(f => f.Key == item.Key);
                        //note.Key = item.Key;
                        var note = MyNotes.FirstOrDefault(f => f.Key == item.Key);
                        if (note != null)
                        {
                            //item.Object.Key = note.Key;
                            MyNotes.Remove(note);                         
                        }
                        item.Object.Key = item.Key;
                        MyNotes.Add(item.Object);
                    }
                });
        }
 
        [RelayCommand]
        public async Task InsertRemark(string remark)
        {
            if (IsLogin)
            {
                if (SelectedNote != null)
                {
                    SelectedNote.Remark = remark;
                    await firebaseClient
                        .Child("users")
                        .Child(_user.Id)
                        .Child(SelectedNote.Key)
                        .PutAsync(SelectedNote);
                }
                else
                {
                    await firebaseClient.Child("users").Child(_user.Id).PostAsync(new NoteModel
                    {
                        Remark = remark,
                    });
                }

                InputMode = "Save";
                return;
            }
             
        }

        [RelayCommand]
        public async Task GetUser()
        {
            if (IsLogin)
            {
                User = _authService.GetUser();
                return;
            }
            await Shell.Current.DisplayAlert("Please Login", "Login", "Ok");
        }

        [RelayCommand]
        public async Task IsUserLogin()
        {
            IsLogin = await _authService.IsLogin();
            await GetUser();
            if (IsLogin)
            {
                WelcomeMsg = $"Welcome {User.username}!";
                var opt = new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(User.token) };

                firebaseClient = new FirebaseClient("https://maui-fuelprice-default-rtdb.firebaseio.com/", opt);
            } 
        }

        [RelayCommand]
        public async Task LogoutUser()
        {
            await _authService.LogoutWithEmail();
            IsLogin = await _authService.IsLogin();
            await Shell.Current.DisplayAlert("Status: Logout Success", "Logout Success", "Ok");
        }

        [RelayCommand]
        public async Task SendPasswordResetEmail()
        {
            await _authService.SendPasswordResetEmail(User.email);
            await Shell.Current.DisplayAlert("Status: Reset Password Email Is Sent", "Login Success", "Ok");
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
                await IsUserLogin();
                FillList();
                await AppShell.Current.GoToAsync(nameof(UserPage));
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
                username = User.username,
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
