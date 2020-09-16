using BcuV0._3.Models.BaseRepo;
using BcuV0._3.Models.Scaffold1;
using System.Collections.Generic;

namespace BcuV0._3.Models.SectionRepo
{
    public class SectionsRepo : Repository<Sections>, ISectionsRepo
    {
        private readonly Var_2Context _context;

        public SectionsRepo(Var_2Context context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Posts> GetMostLikedNPosts()
        {
            throw new System.NotImplementedException();
        }

        public Posts GetMostLikedPost()
        {
            throw new System.NotImplementedException();
        }
    }
}
