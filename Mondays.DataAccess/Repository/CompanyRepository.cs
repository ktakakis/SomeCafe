using Mondays.DataAccess.Data;
using Mondays.DataAccess.Repository.IRepository;
using Mondays.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondays.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void save(Company company)
        {
            _db.Update(company);
        }
    }
}
