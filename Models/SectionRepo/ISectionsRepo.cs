using BcuV0._3.Models.BaseRepo;
using BcuV0._3.Models.Scaffold1;
using System.Collections.Generic;

namespace BcuV0._3.Models.SectionRepo
{
    public interface ISectionsRepo : IRepository<Sections>
    {
        public Posts GetMostLikedPost();
        public IEnumerable<Posts> GetMostLikedNPosts();
    }
}
