using GasAgency.Helpers;
using GasAgency.Models;
using GasAgency.Services;
using MvvmHelpers;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels.ManageClients
{
    public class ClientCRUDViewModel: BaseViewModel
    {
        private bool isEnabled;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if(isEnabled!=value)
                {
                    isEnabled = value;
                }
                OnPropertyChanged("IsEnabled");
            }
        }
        private Client _currentClient;

        public Client CurrentClient
        {
            get
            {
                return _currentClient;
            }
            set
            {
                _currentClient = value;
                OnPropertyChanged("CurrentClient");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _addressLine1;

        public string AddressLine1
        {
            get { return _addressLine1; }
            set
            {
                _addressLine1 = value;
                OnPropertyChanged("AddressLine1");
            }
        }

        private string _addressLine2;

        public string AddressLine2
        {
            get { return _addressLine2; }
            set
            {
                _addressLine2 = value;
                OnPropertyChanged("AddressLine2");
            }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private string _mobile;

        public string Mobile
        {
            get { return _mobile; }
            set
            {
                _mobile = value;
                OnPropertyChanged("Mobile");
            }
        }
        
        public ICommand CreateClientCommand { get; set; }
        public ICommand GetClientCommand { get; set; }
        public ICommand SaveTappedCommand { get; set; }
        public ICommand UpdateClientCommand { get; set; }
        public ICommand DeleteClientCommand { get; set; }
        public ICommand ClearTappedCommand { get; set; }

        public ClientCRUDViewModel()
        {
            CreateClientCommand = new Command(async()=> await AddClient());
            ClearTappedCommand = new Command(ClearInputs);
            DeleteClientCommand = new Command(async() => await DeleteClient());
        }

        private void ClearInputs()
        {
            Name = null;
            AddressLine1 = null;
            AddressLine2 = null;
            Phone = null;
            Mobile = null;
        }

        public ClientCRUDViewModel(int id)
        {
            IsEnabled = false;
            CurrentClient = new Client();
            DeleteClientCommand = new Command(async () => await DeleteClient());
            UpdateClientCommand = new Command(async () => await UpdateClient());
            SaveTappedCommand = new Command(async () => await SaveClient());
            GetClientCommand = new Command(async () => await GetClient(id));
            ClearTappedCommand = new Command(async () => await ClearEdits(id));
            GetClientCommand.Execute(new Command(async () => await GetClient(id)));
        }

        private async Task ClearEdits(int id)
        {
            await GetClient(id);
        }

        private async Task SaveClient()
        {
            await App.Database.SaveClientAsync(CurrentClient);
            MessagingCenter.Send<ClientCRUDViewModel>(this, "Data Updated");
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async Task GetClient(int id)
        {
            CurrentClient = await App.Database.GetClientAsync(id);
        }

        private async Task UpdateClient()
        {
            IsEnabled = true;
        }

        private async Task DeleteClient()
        {
            var result = await App.Current.MainPage.DisplayAlert($"Delete {CurrentClient.Name}", $"Are you sure you want to delete {CurrentClient.Name}", "Yes","No");
            if(result)
            {
                await App.Database.DeleteClientAsync(CurrentClient);
                MessagingCenter.Send<ClientCRUDViewModel>(this, "Data Updated");
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        private async Task AddClient()
        {
            CurrentClient = new Client();
            CurrentClient.Name = Name;
            CurrentClient.AddressLine1 = AddressLine1;
            CurrentClient.AddressLine2 = AddressLine2;
            CurrentClient.Phone = Phone;
            CurrentClient.Mobile = Mobile;
            //var data = DependencyService.Get<IDataStore<Client>>();
            //data.AddItemAsync(CurrentClient);
            await App.Database.SaveClientAsync(CurrentClient);
            MessagingCenter.Send<ClientCRUDViewModel>(this,"Data Updated");
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
