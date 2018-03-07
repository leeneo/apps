using System;
using Microsoft.AspNetCore.Identity;

namespace CcMis.Models
{
    public class WebappUser : IdentityUser<string>
    {
        public WebappUser()
        {
            Id = Guid.NewGuid().ToString("D");
        }
        public WebappUser(string name)
        {
            base.UserName = name;
        }

    }
}
