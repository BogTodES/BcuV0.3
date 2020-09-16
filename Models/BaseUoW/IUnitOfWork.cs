using BcuV0._3.Models.BlogsRepo;
using BcuV0._3.Models.PostRepo;
using BcuV0._3.Models.SectionRepo;
using BcuV0._3.Models.Varutrepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.Models.BaseUoW
{
    public interface IUnitOfWork : IDisposable
    {
        public IVarutRepo Varuti { get; set; }
        public IBlogRepo Blogs{ get; set; }
        public IPostsRepo Posts { get; set; }
        public ISectionsRepo Sections { get; set; }

        int Complete();
    }
}
