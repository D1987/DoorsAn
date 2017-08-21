using System.Collections.Generic;
using DoorsAn1.Data.Models;

namespace DoorsAn1.Data.interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}