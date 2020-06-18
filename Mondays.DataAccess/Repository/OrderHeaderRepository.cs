using Mondays.DataAccess.Data;
using Mondays.DataAccess.Repository.IRepository;
using Mondays.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondays.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void save(OrderHeader obj)
        {
            _db.Update(obj);
        }
    }
}
