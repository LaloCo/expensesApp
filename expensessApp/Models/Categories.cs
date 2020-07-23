using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace expensessApp.Models
{
    public static class Categories
    {
        public static ObservableCollection<string> CategoriesCollection { get; private set; }

        static Categories()
        {
            CategoriesCollection = new ObservableCollection<string>
            {
                "Housing",
                "Debt",
                "Health",
                "Food",
                "Personal",
                "Travel",
                "Other"
            };
        }
    }
}
