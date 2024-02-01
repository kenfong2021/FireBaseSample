using FireBaseAuth.Services;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBaseAuth.Services
{
    public class PhoneAuthenticationService : IPhoneAuthenticationService
    {
        public Task<bool> AuthenticateMobile(string mobile)
        {
            return Task.FromResult(true);
        }
    }
}
