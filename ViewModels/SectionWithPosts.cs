using BcuV0._3.Models.Scaffold2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.ViewModels
{
    public class SectionWithPosts
    {
        public string Name { get; set; }
        public IEnumerable<Posts> Posts { get; set; }

        public SectionWithPosts(Sections sect, IEnumerable<Posts> posts)
        {
            Name = sect.Name;
            Posts = posts;
        }
    }
}
