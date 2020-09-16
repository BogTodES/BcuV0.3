using BcuV0._3.Models.Scaffold1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.ViewModels
{
    public class BlogWithUserInfo
    {
        public BlogWithUserInfo(Blogs blog, Varuti var)
        {
            BlogTitle = blog.Title;
            UserName = var.Nume;
            BlogId = blog.Id;
        }

        public string BlogTitle { get; set; }
        public string UserName { get; set; }
        public int BlogId { get; set; }
    }
}
