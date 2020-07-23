using System;
using System.ComponentModel;
using expensessApp.Models;

namespace ExpensesApp.ViewModels
{
    public class ExpenseDetailsVM : INotifyPropertyChanged
    {
        private Expense _expense;
        public Expense Expense
        {
            get { return _expense ??= new Expense(); }
            set
            {
                _expense = value;
                OnPropertyChanged("Expense");
            }
        }

        public ExpenseDetailsVM()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
