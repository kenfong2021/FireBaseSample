using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBaseAuth.Services
{
    public interface IPhoneAuthenticationService
    {
        Task<bool> AuthenticateMobile(string mobile);
    }
}
