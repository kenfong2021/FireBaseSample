using Firebase.Auth;
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
        private readonly String webApikey = "AIzaSyDevmg5Np2DwyhBNM8OgH0A9-uQqBSLtjM"; // Type your web api key
        private User _user;
        public bool isLogin = false;

        public UserModel GetUser()
        {
            UserModel model = new UserModel
            {
                username = _user.DisplayName,
                email = _user.Email,
                password = "",
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
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApikey));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(user.email.Trim(), user.password.Trim());
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
            _user = new User();
            isLogin = false;
        }

        public async Task SendPasswordResetEmail(string email)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApikey));
            await authProvider.SendPasswordResetEmailAsync(email.Trim());
        }

        public async Task<bool> RegisterUserWithEmail(UserModel user)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApikey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(user.email.Trim(), user.password.Trim(), user.username.Trim());
 
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
