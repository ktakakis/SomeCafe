using Mondays.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mondays.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void save(CoverType coverType);
    }
}
