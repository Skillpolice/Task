using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exzam_Denis_R.Models
{
    public class AppUser:IdentityUser
    {
        public string Login{ get; set; }
        public AppUser()
        {

        }
    }
}