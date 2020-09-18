using BcuV0._3.Models.BaseRepo;
using BcuV0._3.Models.Scaffold2;
using System.Collections.Generic;

namespace BcuV0._3.Models.SectionRepo
{
    public interface ISectionsRepo : IRepository<Sections>
    {
        public IEnumerable<Sections> SectionsForBlogId(int Id);
        public int GetLastInsertedId();
    }
}
