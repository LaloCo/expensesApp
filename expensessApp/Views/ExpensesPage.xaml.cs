using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using expensessApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace expensessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        private ExpensesVM _viewModel;
        public ExpensesPage()
        {
            InitializeComponent();
            _viewModel = Resources["Vm"] as ExpensesVM;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.GetExpenses();
        }
    }
}