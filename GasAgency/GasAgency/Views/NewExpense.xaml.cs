using GasAgency.Models;
using GasAgency.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewExpense : ContentPage
	{
        public ExpenseViewModel ViewModel { get; set; }

        public NewExpense ()
		{
            try
            {
                InitializeComponent();
                this.BindingContext = new ExpenseViewModel(); 
            }
            catch (Exception ex)
            {
                var t = ex.Message;
                throw;
            }
        }
    }
}