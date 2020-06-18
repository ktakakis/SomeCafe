using Mondays.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mondays.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void save(Product product);
    }
}
