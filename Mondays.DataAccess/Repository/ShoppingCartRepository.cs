using Mondays.DataAccess.Data;
using Mondays.DataAccess.Repository.IRepository;
using Mondays.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondays.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void save(ShoppingCart obj)
        {
            _db.Update(obj);
        }
    }
}
