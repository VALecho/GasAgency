using GasAgency.Models;
using GasAgency.Views;
using GasAgency.Views.Clients;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels.ManageClients
{
    class ClientsListViewModel : BaseViewModel
    {
        public ICommand AddClientTappedCommand { get; set; }

        public ICommand DeleteClientTappedCommand { get; set; }

        public  ICommand ListItemTappedCommand { get; set; }

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
        }

        private Client _selectedClient;

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        public ClientsListViewModel()
        {
            Clients = new ObservableCollection<Client>();
            MessagingCenter.Subscribe<ClientCRUDViewModel>(this,"Data Updated", async (sender)=>
            {
                Clients = new ObservableCollection<Client>(await App.Database.GetClientsAsync());
            });
            AddClientTappedCommand = new Command(NavigateToAddClient);
            ListItemTappedCommand = new Command(NavigateToClientDetailsPage);
            GetClients();
        }

        private void NavigateToClientDetailsPage(object obj)
        {
            //MessagingCenter.Send<this>(this, );
            App.Current.MainPage.Navigation.PushAsync(new ClientDetails(SelectedClient.ClientId));
        }

        private void NavigateToAddClient(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new AddClient());
        }

        private async Task GetClients()
        {
            Clients = new ObservableCollection<Client>(await App.Database.GetClientsAsync());
        }
    }
}
