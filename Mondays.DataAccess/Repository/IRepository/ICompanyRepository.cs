using Mondays.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mondays.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void save(Company company);
    }
}
