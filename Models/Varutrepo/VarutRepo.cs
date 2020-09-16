using BcuV0._3.Models.BaseRepo;
using BcuV0._3.Models.Scaffold1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.Models.Varutrepo
{
    public class VarutRepo : Repository<Varuti>, IVarutRepo
    {
        private readonly Var_2Context _context;

        public VarutRepo(Var_2Context context) : base(context)
        {
            this._context = context;
        }

        public Varuti GetByName(string name)
        {
            return
                this._context.Varuti.Where(v => v.Nume == name).FirstOrDefault();
        }
    }
}
