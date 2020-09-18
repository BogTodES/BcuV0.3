using BcuV0._3.Models.BaseRepo;
using BcuV0._3.Models.Scaffold2;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace BcuV0._3.Models.SectionRepo
{
    public class SectionsRepo : Repository<Sections>, ISectionsRepo
    {
        private readonly Var_2Context _context;

        public SectionsRepo(Var_2Context context) : base(context)
        {
            this._context = context;
        }

        public int GetLastInsertedId()
        {
            return
                _context.Sections.OrderByDescending(s => s.Id).FirstOrDefault().Id;
        }

        public IEnumerable<Sections> SectionsForBlogId(int Id)
        {
            var blogSections = _context.BlogsSections;

            var sectIds = blogSections.Where(bs => bs.BlogId == Id)
                                       .Select(bs => bs.SectionId);

            var sections = new List<Sections>();
            foreach(var id in sectIds)
            {
                sections.Add(GetById(id));
            }

            return sections;
        }
    }
}
