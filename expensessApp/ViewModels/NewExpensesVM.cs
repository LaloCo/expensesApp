using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using expensessApp.Models;
using MijnReizen.BLL.Helpers;
using Xamarin.Forms;

namespace expensessApp.ViewModels
{
    class NewExpensesVM : ModelBase
    {

        private Expense _expense;
        public Expense Expense
        {
            get
            {
                return _expense ??= new Expense();
            }
            set
            {
                if (_expense == value) return;
                _expense = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> Categories => Models.Categories.CategoriesCollection;

        public Command SaveCommand
        {
            get;
            private set;
        }

        public NewExpensesVM()
        {
            SaveCommand = new Command(InsertExpense);
        }

        public void InsertExpense()
        {
            var response = Expense.InsertExpense(Expense);

            if (response > 0)
            {
                Application.Current.MainPage.Navigation.PopAsync();
                Expense = new Expense();
            }
            else
                Application.Current.MainPage.DisplayAlert("Error", "No items where inserted", "Ok");
        }
    }
}
