using BcuV0._3.Models.BaseRepo;
using BcuV0._3.Models.Scaffold2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.Models.BlogsRepo
{
    public class BlogsRepository : Repository<Blogs>, IBlogRepo
    {
        private readonly Var_2Context _entities;

        public BlogsRepository(Var_2Context context) : base(context)
        {
            this._entities = context;
        }

        public int GetLastInsertedId()
        {
            return
                this._entities.Blogs.OrderByDescending(b => b.Id).FirstOrDefault().Id;
        }

        public Blogs GetMostLiked()
        {
            var q = this.schema().OrderBy(s => s.Value).FirstOrDefault();

            return GetById(q.Key);
            
        }

        public IEnumerable<Blogs> GetMostLikedN(int n)
        {
            var rankLikeuri = schema().OrderBy(s => s.Value).Take(n);

            List<Blogs> temp = new List<Blogs>();

            foreach(var b in rankLikeuri)
            {
                temp.Add(GetById(b.Key));
            }

            return temp;
        }

        private IEnumerable<KeyValuePair<int, int>> schema()
        {
            var blogs = this._entities.Blogs.ToList();
            var blogSects = this._entities.BlogsSections.ToList();
            var comments = this._entities.Comments.ToList();
            var sectPosts = this._entities.SectionsPosts.ToList();
            var postLikes = this._entities.UserPostReacts
                .Where(react => react.ReactId == 1).ToList();
            // presupun ca ID = 1 inseamna like
            var posts = this._entities.Posts.ToList();

            var query1 =
                blogs.Join(blogSects,
                            blogs => blogs.Id,
                            blogSects => blogSects.BlogId,
                            (blog, blogSects) => new { blog.Id, blogSects.SectionId })
                     .Join(sectPosts,
                            sects => sects.SectionId,
                            sectPosts => sectPosts.SectionId,
                            (sects, sectPosts) => new { sects.Id, sectPosts.PostId })
                     .Join(postLikes,
                           sectPosts => sectPosts.PostId,
                           postLikes => postLikes.PostId,
                           (sectPosts, postLikes) => new { sectPosts.Id, postLikes.PostId });


            var temp = new List<KeyValuePair<int, int>>();
            foreach (var blog in query1)
            {
                var count = postLikes.Count(like => like.PostId == blog.PostId);
                temp.Add(new KeyValuePair<int, int>(blog.Id, count));
            }

            return (IEnumerable<KeyValuePair<int, int>>)query1;
        }
    }
}
 