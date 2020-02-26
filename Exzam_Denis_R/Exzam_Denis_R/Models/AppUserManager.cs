using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exzam_Denis_R.Models
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {

        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            AppContext db = context.Get<AppContext>();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));

            //задаем пароль
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireDigit = true
            };
            return manager;
        }
    }
}