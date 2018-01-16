using System.Collections.Generic;
using DoorsAn1.Data.Models;

namespace DoorsAn1.Data.Services.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        Product GetProductById(int productId);
    }
}