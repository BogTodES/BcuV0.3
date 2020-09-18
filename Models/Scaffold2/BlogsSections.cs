using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold2
{
    public partial class BlogsSections
    {
        public int BlogId { get; set; }
        public int SectionId { get; set; }

        public virtual Blogs Blog { get; set; }
        public virtual Sections Section { get; set; }
    }
}
