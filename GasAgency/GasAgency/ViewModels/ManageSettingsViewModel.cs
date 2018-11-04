using GasAgency.Views.Clients;
using GasAgency.Views.Hawkers;
using GasAgency.Views.Products;
using MvvmHelpers;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels
{
    public class ManageSettingsViewModel: BaseViewModel
    {
        public ICommand ManageClientsTappedCommand { get; set; }
        public ICommand ManageProductsTappedCommand { get; set; }
        public ICommand ManageProductCostTappedCommand { get; set; }
        public ICommand ManageHawkersTappedCommand { get; set; }
        public ManageSettingsViewModel()
        {
            ManageClientsTappedCommand = new Command(NavigateToClientsPage);
            ManageHawkersTappedCommand = new Command(NavigateToHawkersPage);
            ManageProductCostTappedCommand = new Command(NavigateToProductCostPage);
            ManageProductsTappedCommand = new Command(NavigateToProductsPage);
        }

        private void NavigateToHawkersPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new HawkersList());
        }

        private void NavigateToProductCostPage(object obj)
        {
            
        }

        private void NavigateToProductsPage(object obj)
        {
           App.Current.MainPage.Navigation.PushAsync(new ProductsList());
        }

        private void NavigateToClientsPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new ClientsList());
        }
    }
}
