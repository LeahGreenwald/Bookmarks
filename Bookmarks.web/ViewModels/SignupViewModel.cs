using Bookmarks.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmarks.web.ViewModels
{
    public class SignupViewModel : User
    {
        public string Password { get; set; }
    }
}
