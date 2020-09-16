using BcuV0._3.Models.BaseRepo;
using BcuV0._3.Models.Scaffold1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.Models.PostRepo
{
    public class PostsRepo : Repository<Posts>, IPostsRepo
    {
        private readonly Var_2Context _context;

        public PostsRepo(Var_2Context context) : base(context)
        {
            this._context = context;
        }

        public int GetDislikes()
        {
            throw new NotImplementedException();
        }

        public int GetLikes()
        {
            throw new NotImplementedException();
        }

        public int GetReactions()
        {
            throw new NotImplementedException();
        }
    }
}
