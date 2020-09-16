using BcuV0._3.Models.BaseUoW;
using BcuV0._3.Models.Scaffold1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.ViewModels
{
    public class BlogWithSectionsAndPosts
    {
        // pagina principala de blog gen
        // le contine pe toate

        private readonly string VarutName;
        private readonly string BlogTitle;
        private readonly IEnumerable<Sections> Sections;
        private readonly IEnumerable<Posts> Posts;
        
    }
}
