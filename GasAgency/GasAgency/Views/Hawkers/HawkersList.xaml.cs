using GasAgency.Models;
using GasAgency.ViewModels.ManageClients;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.Views.Clients
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClientsList : ContentPage
	{
		public ClientsList ()
		{
			InitializeComponent ();
            this.BindingContext = new ClientsListViewModel();
		}

        private void ListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ClientDetails(((Client)e.Item).ClientId));
            ((ListView)sender).SelectedItem = null;
        }
    }
}