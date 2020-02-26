using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exzam_Denis_R.Models
{
    public class AppDbIni : DropCreateDatabaseIfModelChanges<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            var userManager = new AppUserManager(new UserStore<AppUser>(context));

            var roleManager = new AppRoleManager(new RoleStore<IdentityRole>(context));

            //создаем роль
            var role1 = new IdentityRole("admin");
            var role2 = new IdentityRole("user");

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new AppUser
            {
                Email = "admin@mail.ru",
                UserName = "Boss",
                Login = "Sup"
                
            };


            string password = "123456";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            base.Seed(context);

        }
    }
}