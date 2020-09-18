using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold2
{
    public partial class ReactTypes
    {
        public ReactTypes()
        {
            UserCommentReacts = new HashSet<UserCommentReacts>();
            UserPostReacts = new HashSet<UserPostReacts>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<UserCommentReacts> UserCommentReacts { get; set; }
        public virtual ICollection<UserPostReacts> UserPostReacts { get; set; }
    }
}
