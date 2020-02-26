using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exzam_Denis_R.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }
        public virtual Theme Theme { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}