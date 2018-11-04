using GasAgency.Models;
using GasAgency.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewSale : ContentPage
	{
        public SaleViewModel ViewModel { get; set; }

        public NewSale ()
		{
            try
            {
                InitializeComponent();
                ViewModel = new SaleViewModel();
                this.BindingContext = ViewModel;
            }
            catch (Exception ex)
            {
                var t = ex.Message; 
                throw;
            }
		}

        private void comboBox_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            ViewModel.SelectedProduct = e.Value != null ? e.Value as Product : null; 
        }

        private void comboMode_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            ViewModel.SelectedMode = (string)e.Value == "CASH" ? TransactionMode.Cash : TransactionMode.Credit;
        }

        private void comboClients_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            ViewModel.SelectedClient = e.Value != null? e.Value as Client : null; 
        }
    }
}