using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorsAn1.Data.interfaces;
using DoorsAn1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsAn1.Data.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> Products => _appDbContext.Products.Include(c => c.Category);

        public Product GetProductById(int productId) => _appDbContext.Products
            .FirstOrDefault(p => p.ProductId == productId);


    }
}
