using System;
using System.Collections.Generic;

namespace BcuV0._3.Models.Scaffold1
{
    public partial class Varuti
    {
        public Varuti()
        {
            Blogs = new HashSet<Blogs>();
            UserCommentReacts = new HashSet<UserCommentReacts>();
            UserPostReacts = new HashSet<UserPostReacts>();
        }

        public string Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int BlogId { get; set; }

        public virtual ICollection<Blogs> Blogs { get; set; }
        public virtual ICollection<UserCommentReacts> UserCommentReacts { get; set; }
        public virtual ICollection<UserPostReacts> UserPostReacts { get; set; }
    }
}
