using expensessApp.Models;
using expensessApp.Views;
using System.Collections.ObjectModel;
using expensessApp.Interfaces;
using Xamarin.Forms;

namespace expensessApp.ViewModels
{
    class ExpensesVM
    {
        private ObservableCollection<Expense> _expenses;
        public ObservableCollection<Expense> Expenses
        {
            get => _expenses ??= _expenses =  new ObservableCollection<Expense>();

            set
            {
                if (value == Expenses)
                    return;
                Expenses = value;
            }
        }


        public Command<Expense> DeleteExpenseCommand => new Command<Expense>((expense) =>
        {
            if (expense == null) return;

            Expense.DeleteExpense(expense);
            Expenses.Remove(expense);
        });

        public Command AddExpenseCommand { get; private set; }          

        public ExpensesVM()
        {
            GetExpenses();
            AddExpenseCommand = new Command(AddExpense);
        }

        public void GetExpenses()
        {
            var expenses = Expense.GetExpenses();
            Expenses.Clear();
            foreach (var expense in expenses)
            {
                    Expenses.Add(expense);
            }
        }

        public void AddExpense()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensesPage());
        }

        
    }
}
