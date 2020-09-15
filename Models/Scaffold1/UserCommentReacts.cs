using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold1
{
    public partial class UserCommentReacts
    {
        public string UserId { get; set; }
        public int CommentId { get; set; }
        public int ReactId { get; set; }

        public virtual Comments Comment { get; set; }
        public virtual ReactTypes React { get; set; }
        public virtual Varuti User { get; set; }
    }
}
