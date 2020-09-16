using BcuV0._3.Models.BaseRepo;
using BcuV0._3.Models.Scaffold1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.Models.BlogsRepo
{
    public interface IBlogRepo : IRepository<Blogs>
    {
        public Blogs GetMostLiked();
        public IEnumerable<Blogs> GetMostLikedN(int n);
        public int GetLastInsertedId();
    }
}
