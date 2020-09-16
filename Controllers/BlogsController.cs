using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BcuV0._3.Models.BaseUoW;
using BcuV0._3.Models.Scaffold1;
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
            // daca intru aici, in primul rand am un user logat
            // aflu datele, extrag blog-ul corespunzator/il creez daca nu exista

            var userName = User.Identity.Name;
            if (userName is null)
            {
                return View("BlogUnavailable", $"userName = {userName}");
            }

            var user = _unit.Varuti.GetByName(userName);
            if(user is null)
            {   

                return View("BlogUnavailable", $"user = {user.Id} {user.Nume}");
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
                newBlog.Id = blogId;
                selectedBlog = newBlog;


                _unit.Varuti.Update(user);
                _unit.Complete();
            }
            else
            {
                // daca exista dinainte, doar il scot din bd
                selectedBlog = _unit.Blogs.GetById(blogId);
            }
            
            if(selectedBlog is null)
            {
                return View("BlogUnavailable", $"blogID = {blogId}");
            }

            return View("ShowBlog", selectedBlog);
        }
    }
}
