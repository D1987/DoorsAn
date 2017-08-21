using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoorsAn1.ViewModels
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; } // значение для сортировки по имени
        public SortState CategorySort { get; private set; }
        public SortState StatusSort { get; private set; }
        public SortState Current { get; private set; }  // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            CategorySort = sortOrder == SortState.CategoryAsc ? SortState.CategoryDesc : SortState.CategoryAsc;
            StatusSort = sortOrder == SortState.StatusAsc ? SortState.StatusDesc : SortState.StatusAsc;
            Current = sortOrder;
        }
    }
}
