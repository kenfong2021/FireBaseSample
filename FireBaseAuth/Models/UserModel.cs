using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBaseAuth.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string token { get; set; }
    }
}
