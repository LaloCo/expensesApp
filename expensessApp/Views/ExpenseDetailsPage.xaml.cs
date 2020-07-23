using System;
using System.Collections.Generic;
using ExpensesApp.ViewModels;
using expensessApp.Models;
using Xamarin.Forms;

namespace ExpensesApp.Views
{
    public partial class ExpenseDetailsPage : ContentPage
    {
        ExpenseDetailsVM ViewModel;
        public ExpenseDetailsPage()
        {
            InitializeComponent();
        }

        public ExpenseDetailsPage(Expense expense)
        {
            InitializeComponent();

            ViewModel = Resources["vm"] as ExpenseDetailsVM;
            ViewModel.Expense = expense;
        }
    }
}
