using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold2
{
    public partial class SectionsPosts
    {
        public int SectionId { get; set; }
        public int PostId { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Sections Section { get; set; }
    }
}
