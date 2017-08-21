using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorsAn1.Data.interfaces;
using DoorsAn1.Data.Models;

namespace DoorsAn1.Data.mocks
{
    public class MockCategoryRepository:ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category{ CategoryName = "Кровля", Description = "Вся крыша у нас"},
                    new Category{ CategoryName = "Двери", Description = "Все двери у нас"},
                    new Category{ CategoryName = "Забор", Description = "Все заборы у нас"}
                };
            }
            set { throw new NotImplementedException(); }
        }
    }
}
