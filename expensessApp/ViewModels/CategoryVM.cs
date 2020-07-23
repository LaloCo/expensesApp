using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using expensessApp.Interfaces;
using expensessApp.Models;
using PCLStorage;
using Xamarin.Forms;

namespace expensessApp.ViewModels
{
    public class CategoryVM
    {
        public ObservableCollection<string> Categories => Models.Categories.CategoriesCollection;

        private ObservableCollection<CategoryExpense> _categoryExpenses;

        public ObservableCollection<CategoryExpense> CategoryExpenses
        {
            get { return _categoryExpenses ??= new ObservableCollection<CategoryExpense>(); }
            set
            {
                if (value == _categoryExpenses)
                    return;
                _categoryExpenses = value;
            }
        }

        private Command _shareCommand;
        public Command ExportCommand => _shareCommand ??= new Command(ShareReport);

        public CategoryVM()
        {
            GetExpensesPerCategory();
        }



        public void GetExpensesPerCategory()
        {
            CategoryExpenses.Clear();
            var totalExpenseAmount = Expense.TotalExpensesAmount(); 
            foreach (var category in Models.Categories.CategoriesCollection)
            {
                var expenses = Expense.GetExpenses(category);
                var AmountInCategory = expenses.Sum(expense => expense.Amount);

                var categoryExpense = new CategoryExpense()
                {
                    Category = category,
                    ExpensesPercentage = AmountInCategory / totalExpenseAmount
                };
                CategoryExpenses.Add(categoryExpense);
            }
        }

        public async void ShareReport()
        {

            IFileSystem fileSystem = FileSystem.Current;
            IFolder rootFolder = fileSystem.LocalStorage;
            IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);

            var txtFile = await reportsFolder.CreateFileAsync("report.txt", CreationCollisionOption.ReplaceExisting);

            using (StreamWriter sw = new StreamWriter(txtFile.Path))
            {
                foreach (var categoryExpense in CategoryExpenses)
                {
                   await sw.WriteAsync($"{categoryExpense.Category} - {categoryExpense.ExpensesPercentage}");
                }
            }
            
            var shareDependency = DependencyService.Get<IShare>();
            await shareDependency.Show("Expense report", "Here is your expense report", txtFile.Path);
        }


        public class CategoryExpense
        {
            public string Category { get; set; }
            public float ExpensesPercentage { get; set; }

            public CategoryExpense()
            {
                
            }
        }
    }
}
