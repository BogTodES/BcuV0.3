using BcuV0._3.Models.BaseRepo;
using BcuV0._3.Models.Scaffold2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.Models.Varutrepo
{
    public interface IVarutRepo : IRepository<Varuti>
    {
        public Varuti GetByName(string name);
    }
}
