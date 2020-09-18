using BcuV0._3.Models.Scaffold2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.ViewModels
{
    public class BUSPosts
    {
        public BlogUserSections MainInfo { get; set; }
        public Dictionary<int, IEnumerable<Posts>> PostsMap { get; set; }
                       //sectID     //posts

        public BUSPosts(BlogUserSections blogUserSections, 
            Dictionary<int, IEnumerable<Posts>> postsMap)
        {
            MainInfo = blogUserSections;
            PostsMap = postsMap;
        }
    }
}
