using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using FireBaseAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBaseAuth.Services
{
    public class AuthService : IAuthService
    {
        //private readonly String webApikey = "AIzaSyDevmg5Np2DwyhBNM8OgH0A9-uQqBSLtjM"; // Type your web api key
        private User _user;
        private static FirebaseAuthConfig _config = new FirebaseAuthConfig
        {
            ApiKey = "AIzaSyDevmg5Np2DwyhBNM8OgH0A9-uQqBSLtjM",
            AuthDomain = "maui-fuelprice.firebaseapp.com",
            Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                    {
                        // Add and configure individual providers
                        new EmailProvider()
                    },

        };
        private static FirebaseAuthClient _firebaseAuthClient = new FirebaseAuthClient(_config);
        public bool isLogin = false;

        public UserModel GetUser()
        {
            UserModel model = new UserModel
            {
                Id = _user.Uid,
                username = _user.Info.DisplayName,
                email = _user.Info.Email,
                token = _user.GetIdTokenAsync().Result,
            };

            return model;
        }

        public async Task<bool> IsLogin()
        {
            await Task.Delay(10);
            return isLogin;
        }
        public async Task<bool> LoginUserWithEmail(UserModel user)
        {
            try
            { 
                var auth = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(user.email.Trim(), user.password.Trim());
               _user = auth.User;

                isLogin = true;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task LogoutWithEmail()
        {
            await Task.Delay(10);
            _user = null;
            isLogin = false;
        }

        public async Task SendPasswordResetEmail(string email)
        {
            await _firebaseAuthClient.ResetEmailPasswordAsync(email.Trim());
        }

        public async Task<bool> RegisterUserWithEmail(UserModel user)
        {
            try
            {
                var auth = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(user.email.Trim(), user.password.Trim(), user.username.Trim());
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
