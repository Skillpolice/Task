using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Exzam_Denis_R.Models;
using AppContext = Exzam_Denis_R.Models.AppContext;
using System.Threading.Tasks;
using System.Reflection;

namespace Exzam_Denis_R.Controllers
{
    public class HomeController : Controller
    {
        AppContext db = new AppContext();
        public Models.AppContext Context
        {
            get
            {
                return HttpContext.GetOwinContext().Get < Models.AppContext>();
            }
        }

        public ActionResult Index()
        {
            IEnumerable<Post> posts = db.Posts.Where(p=>p.ThemeId==2).ToList();
            //IEnumerable<PostThemes> postThemess = Context.PostThemes.ToList();
            return View(posts);
            
        }

        [HttpGet]
        public ActionResult AddPost()
        {
           
            return PartialView("AddpostPartial");
        }
        [HttpPost]
        public ActionResult AddPost(String Text)
        {
            Post post = new Post();
            post.Text = Text;
            post.Time = DateTime.Now;

            //получаем пользователя
            AppUser user = UserManager.FindByName(User.Identity.Name);
            post.AppUser = user;
            post.ThemeId = 2;
            Context.Posts.Add(post);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PostThemes(int id)
        {
            IEnumerable<Post> post = Context.Posts.Where(p=>p.ThemeId == id);
            string viewName="" ;
            if (id == 1)
            {
                viewName = "PostThemes";
            }
            else if( id == 3)
            {
                viewName = "PostThemesDog";
            }
            else if (id == 4)
            {
                viewName = "PostThemesAnt";
            }

            return PartialView(viewName,post.ToList());
        }
        [HttpPost]
        public ActionResult PostThemes(String Text,int themeId)
        {
            Post post = new Post();
            post.Text = Text;
            post.Time = DateTime.Now;
            post.ThemeId = themeId;

            //получаем пользователя
            AppUser user = UserManager.FindByName(User.Identity.Name);
            post.AppUser = user;
            Context.Posts.Add(post);
            Context.SaveChanges();
         
            return RedirectToAction("PostThemes", new { id = themeId });
        }


        AppUserManager UserManager
        {
            get => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        }


       [HttpGet]
        public ActionResult Delete(int id)
        {
            Post p = Context.Posts.Find(id);
            if (p!= null)
            {
                Context.Posts.Remove(p);
                Context.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post p = Context.Posts.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            Context.Posts.Remove(p);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        //пользователи
        [Authorize(Roles = "admin,user", Users = "Boss,qqq")]
        [HttpGet]
        public ActionResult AllUsers()
        {
            IEnumerable<AppUser> users = Context.Users.ToList();
            UserManager.GetRoles(User.Identity.GetUserId());
            return View(users);
        }
    }
}