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
    public class BlogsController : Controller
    {
        private readonly IUnitOfWork _unit;

        public BlogsController(IUnitOfWork unit)
        {
            this._unit = unit;
        }

        public IActionResult Index()
        {
            return BlogOf(User.Identity.Name);
        }

        public IActionResult BlogOf(string Name)
        {
            // daca intru aici, in primul rand am un user logat
            // aflu datele, extrag blog-ul corespunzator/il creez daca nu exista

            var userName = Name;
            if (userName is null)
            {
                return View("BlogUnavailable", $"Username este null");
            }

            var user = _unit.Varuti.GetByName(userName);
            if(user is null)
            {   
                return View("BlogUnavailable", $"Nu am gasit {user.BlogId}");
            }

            var blogId = user.BlogId;
            Blogs selectedBlog = null;
            if(blogId == 0)
            {
                // este prima data cand acceseaza pagina asta, nu are blog => creez unul pe loc
                var newBlog = new Blogs()
                {
                    UserId = user.Id,
                    Title = "Blog-ul tau"
                };
                _unit.Blogs.Add(newBlog);
                _unit.Complete();

                user.BlogId = _unit.Blogs.GetLastInsertedId();
                blogId = user.BlogId;
                newBlog.Id = blogId ?? 0;
                selectedBlog = newBlog;

                _unit.Varuti.Update(user);
                _unit.Complete();
            }
            else
            {
                // daca exista dinainte, doar il scot din bd
                selectedBlog = _unit.Blogs.GetById(blogId ?? 0);
            }
            
            if(selectedBlog is null)
            {
                return View("BlogUnavailable", "Could not find blog.");
            }

            // return View("ShowBlog", new BlogWithUserInfo(selectedBlog, user));
            return FillSections(selectedBlog, user);
        }

        public IActionResult FillSections(Blogs selectedBlog, Varuti user)
        {
            // construiesc progresiv view-ul
            // adaug sectiunile

            var sectionList =
                _unit.Sections.SectionsForBlogId(selectedBlog.Id);

            if(sectionList is null)
            {
                return View("BlogUnavailable", "Error on loading sections");
            }

            return FillPosts(new BlogUserSections(selectedBlog, user, sectionList));
        }

        private IActionResult FillPosts(BlogUserSections combinedModel)
        {
            var postToSectsMap = new Dictionary<int, IEnumerable<Posts>>();

            foreach(var sect in combinedModel.Sections)
            {
                var posts = _unit.Posts.AllPostsForSectionId(sect.Id);
                postToSectsMap.Add(sect.Id, posts);
            }

            return View("ShowBlogPage", new BUSPosts(combinedModel, postToSectsMap));
        }
    }
}
