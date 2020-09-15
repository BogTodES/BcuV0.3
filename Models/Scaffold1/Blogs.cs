using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold1
{
    public partial class Blogs
    {
        public Blogs()
        {
            BlogsSections = new HashSet<BlogsSections>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }

        public virtual Varuti User { get; set; }
        public virtual ICollection<BlogsSections> BlogsSections { get; set; }
    }
}
