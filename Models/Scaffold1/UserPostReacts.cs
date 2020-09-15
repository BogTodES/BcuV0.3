using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold1
{
    public partial class UserPostReacts
    {
        public string UserId { get; set; }
        public int PostId { get; set; }
        public int ReactId { get; set; }

        public virtual Posts Post { get; set; }
        public virtual ReactTypes React { get; set; }
        public virtual Varuti User { get; set; }
    }
}
