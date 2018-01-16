using System.Collections.Generic;
using DoorsAn1.Data.Models;

namespace DoorsAn1.Data.Services.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}