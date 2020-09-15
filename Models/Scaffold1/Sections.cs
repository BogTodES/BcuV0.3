using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold1
{
    public partial class Sections
    {
        public Sections()
        {
            BlogsSections = new HashSet<BlogsSections>();
            SectionsPosts = new HashSet<SectionsPosts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BlogsSections> BlogsSections { get; set; }
        public virtual ICollection<SectionsPosts> SectionsPosts { get; set; }
    }
}
