using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BcuV0._3.Models.BaseUoW;
using BcuV0._3.Models.Scaffold2;
using BcuV0._3.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BcuV0._3.Controllers
{
    public class SectionController : Controller
    {
        private readonly IUnitOfWork _unit;

        public SectionController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult SeeDetailsOfSection(int id)
        {
            // afisez detaliile sectiunii
            var section = _unit.Sections.GetById(id);
            var posts = _unit.Posts.AllPostsForSectionId(id);

            return View("DetailsOfSection", new SectionWithPosts(section, posts));
        }

        public IActionResult CreateNew(int blogId)
        {
            // generez o sectiune noua default si o deschid

            var newSect = new Sections()
            {
                Name = "Temp"
            };



            var newLegatura = new BlogsSections()
            {
                BlogId = blogId,
            };

            return SeeDetailsOfSection(_unit.Sections.GetLastInsertedId());
        }
    }
}
