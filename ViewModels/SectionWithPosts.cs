using BcuV0._3.Models.Scaffold1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.ViewModels
{
    public class SectionWithPosts
    {
        public Sections Section { get; set; }
        public IEnumerable<Posts> Posts { get; set; }

        public SectionWithPosts(Sections section, IEnumerable<Posts> posts)
        {
            Section = section;
            Posts = posts;
        }
    }
}
