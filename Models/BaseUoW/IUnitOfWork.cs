using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BcuV0._3.Models.BaseUoW
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
