using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MijnReizen.BLL.Helpers;

namespace expensessApp.Models
{
    public class Expense : ModelBase
    {

        private int _id;
        
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == value) return;

                _id = value;
                RaisePropertyChanged();
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;

                _name = value;
                RaisePropertyChanged();
            }
        }


        private float _amount;
        public float Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (_amount == value) return;

                _amount = value;
                RaisePropertyChanged();
            }
        }

        private string _description;
        [MaxLength(25)]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description == value) return;

                _description = value;
                RaisePropertyChanged();
            }
        }
        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (_date == value) return;

                _date = value;
                RaisePropertyChanged();
            }
        }

        private string _category;
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                if (_category == value) return;

                _category = value;
                RaisePropertyChanged();
            }
        }


        public Expense()
        {
            Date = DateTime.Today;
        }

        public static int InsertExpense(Expense expense)
        { 
            using var connection = new SQLiteConnection(App.DatabasePath);
            connection.CreateTable<Expense>();
            return connection.Insert(expense);
        }

        public static List<Expense> GetExpenses()
        {
            using var connection = new SQLiteConnection(App.DatabasePath);
            connection.CreateTable<Expense>();
            return connection.Table<Expense>().ToList();
        }
        public static List<Expense> GetExpenses(string category)
        {
            using var connection = new SQLiteConnection(App.DatabasePath);
            connection.CreateTable<Expense>();
            return connection.Table<Expense>().Where(e => e.Category.Equals(category)).ToList();
        }

        public static float TotalExpensesAmount()
        {
            using var connection = new SQLiteConnection(App.DatabasePath);
            connection.CreateTable<Expense>();
            return connection.Table<Expense>().ToList().Sum(item => item.Amount);
        }

        public static int DeleteExpense(Expense expense)
        {
            using var connection = new SQLiteConnection(App.DatabasePath);
            connection.CreateTable<Expense>();
            return connection.Delete<Expense>(expense.Id);
        }

    }
}
