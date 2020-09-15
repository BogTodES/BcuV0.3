using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold1
{
    public partial class Posts
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
            SectionsPosts = new HashSet<SectionsPosts>();
            UserPostReacts = new HashSet<UserPostReacts>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<SectionsPosts> SectionsPosts { get; set; }
        public virtual ICollection<UserPostReacts> UserPostReacts { get; set; }
    }
}
