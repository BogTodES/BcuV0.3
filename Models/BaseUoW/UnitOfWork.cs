using BcuV0._3.Models.BlogsRepo;
using BcuV0._3.Models.PostRepo;
using BcuV0._3.Models.Scaffold1;
using BcuV0._3.Models.SectionRepo;
using BcuV0._3.Models.Varutrepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.Models.BaseUoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Var_2Context _context;

        public UnitOfWork(Var_2Context context)
        {
            this._context = context;
            this.Varuti = new VarutRepo(this._context);
            this.Blogs = new BlogsRepository(this._context);
            this.Posts = new PostsRepo(this._context);
            this.Sections = new SectionsRepo(this._context);
        }

        public IVarutRepo Varuti { get; set; }
        public IBlogRepo Blogs { get; set; }
        public IPostsRepo Posts { get; set; }
        public ISectionsRepo Sections { get; set; }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
