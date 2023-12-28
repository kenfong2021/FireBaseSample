using FireBaseAuth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBaseAuth.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUserWithEmail(UserModel user);
        Task<bool> LoginUserWithEmail(UserModel user);
        Task LogoutWithEmail();
        UserModel GetUser();
        Task<bool> IsLogin();
    }
}
