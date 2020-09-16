using BcuV0._3.Models.BaseRepo;
using BcuV0._3.Models.Scaffold1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.Models.PostRepo
{
    public interface IPostsRepo : IRepository<Posts>
    {
        public int GetLikes();
        public int GetDislikes();
        public int GetReactions();
    }
}
