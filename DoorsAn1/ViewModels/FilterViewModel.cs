using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using DoorsAn1.Data.Models;

namespace DoorsAn1.ViewModels
{
    public class FilterViewModel
    {      
        public FilterViewModel()
        {
        }

        public FilterViewModel(List<Category> categories, int? category, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            categories.Insert(0, new Category { CategoryName = "Все", CategoryId = 0 });
            Categories = new SelectList(categories, "CategoryId", "CategoryName", category);
            SelectedCategory = category;
            SelectedName = name;
        }

        public FilterViewModel FilterEditViewModel(List<Category> categories, int? category, string name)
        {
            FilterViewModel _filterViewModel = new FilterViewModel();
            _filterViewModel.Categories = new SelectList(categories, "CategoryId", "CategoryName", category);
            _filterViewModel.SelectedCategory = category;
            _filterViewModel.SelectedName = name;

            return _filterViewModel;
        }
        public SelectList Categories { get; set; }        
        public int? SelectedCategory { get; set; }
        public string SelectedName { get; set; }
}
}
