using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorsAn1.Data.interfaces;
using DoorsAn1.Data.Models;

namespace DoorsAn1.Data.mocks
{
    public class MockProductRepository:IProductRepository
    {
        private ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product
                    {
                        Name = "Крыша зеленая",
                        Price = 500,
                        ShortDescription = "Крыша для дома",
                        LongDescription =
                            "Наша компания продает металлочерепицу в самом полном ассортименте ведущих  европейских производителей кровельных материалов толщиной 0,5 или 0,45 мм . Подробнее: https://vira-treiding.deal.by/g9859-kupit-metallocherepitsu-postavschika",
                        Category = _categoryRepository.Categories.First(),
                        //ImageUrl = "http://imgh.us/beerl_2.jpg",
                        //ImageThumbnailUrl = "http://imgh.us/beers_1.jpg",
                        Status = true,
                        Producer = "РФ"
                    },
                    new Product
                    {
                        Name = "Дверь белая",
                        Price = 500,
                        ShortDescription = "Дверь для дома",
                        LongDescription =
                            "Наша компания продает металлочерепицу в самом полном ассортименте ведущих  европейских производителей кровельных материалов толщиной 0,5 или 0,45 мм . Подробнее: https://vira-treiding.deal.by/g9859-kupit-metallocherepitsu-postavschika",
                        Category = _categoryRepository.Categories.First(),
                        //ImageUrl = "http://imgh.us/beerl_2.jpg",
                        //ImageThumbnailUrl = "http://imgh.us/beers_1.jpg",
                        Status = false,
                        Producer = "РБ"
                    },
                    new Product
                    {
                        Name = "Забор красный",
                        Price = 500,
                        ShortDescription = "Забор для дома",
                        LongDescription =
                            "Наша компания продает металлочерепицу в самом полном ассортименте ведущих  европейских производителей кровельных материалов толщиной 0,5 или 0,45 мм . Подробнее: https://vira-treiding.deal.by/g9859-kupit-metallocherepitsu-postavschika",
                        Category = _categoryRepository.Categories.First(),
                        //ImageUrl = "http://imgh.us/beerl_2.jpg",
                        //ImageThumbnailUrl = "http://imgh.us/beers_1.jpg",
                        Status = true,
                        Producer = "Польша  "
                    },

                };
            }
            set { throw new NotImplementedException(); }
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
