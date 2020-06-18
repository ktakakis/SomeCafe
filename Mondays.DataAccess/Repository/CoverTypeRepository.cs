using Mondays.DataAccess.Data;
using Mondays.DataAccess.Repository.IRepository;
using Mondays.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondays.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void save(CoverType coverType)
        {
            var objFromDb = _db.CoverTypes.FirstOrDefault(s => s.Id == coverType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = coverType.Name;
               
            }
        }
    }
}
