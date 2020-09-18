using BcuV0._3.Models.Scaffold2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.ViewModels
{
    public class BlogUserSections
    {
        public string Title { get; set; }
        public string Username { get; set; }
        public List<Sections> Sections { get; set; }

        public BlogUserSections(Blogs blog, Varuti user, IEnumerable<Sections> sectionList)
        {
            Title = blog.Title;
            Username = user.Nume;
            Sections = sectionList.ToList();
        }
    }
}
