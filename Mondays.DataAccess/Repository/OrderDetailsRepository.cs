using Mondays.DataAccess.Data;
using Mondays.DataAccess.Repository.IRepository;
using Mondays.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondays.DataAccess.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void save(OrderDetails obj)
        {
            _db.Update(obj);
        }
    }
}
