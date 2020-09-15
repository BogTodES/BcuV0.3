using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold1
{
    public partial class Comments
    {
        public Comments()
        {
            UserCommentReacts = new HashSet<UserCommentReacts>();
        }

        public int CommentId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }

        public virtual Posts Post { get; set; }
        public virtual ICollection<UserCommentReacts> UserCommentReacts { get; set; }
    }
}
