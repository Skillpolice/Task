using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exzam_Denis_R.Models
{
    public class AppContext : IdentityDbContext<AppUser>
    {
        public AppContext():base("PostDb")
        {

        }

        public static AppContext Create()
        {
            return new AppContext();
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Theme> Themes { get; set; }
    }
}