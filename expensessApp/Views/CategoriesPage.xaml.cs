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
    public partial class CategoriesPage : ContentPage
    {

        private CategoryVM _viewModel;

        public CategoriesPage()
        {
            InitializeComponent();
            _viewModel = Resources["Vm"] as CategoryVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.GetExpensesPerCategory();
        }
    }
}