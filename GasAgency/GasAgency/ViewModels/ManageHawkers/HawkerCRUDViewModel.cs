using GasAgency.Helpers;
using GasAgency.Models;
using GasAgency.Services;
using MvvmHelpers;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels.ManageHawkers
{
    public class HawkerCRUDViewModel: BaseViewModel
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
        private Hawker _currentHawker;

        public Hawker CurrentHawker
        {
            get
            {
                return _currentHawker;
            }
            set
            {
                _currentHawker = value;
                OnPropertyChanged("CurrentHawker");
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
        
        public ICommand CreateHawkerCommand { get; set; }
        public ICommand GetHawkerCommand { get; set; }
        public ICommand SaveTappedCommand { get; set; }
        public ICommand UpdateHawkerCommand { get; set; }
        public ICommand DeleteHawkerCommand { get; set; }
        public ICommand ClearTappedCommand { get; set; }

        public HawkerCRUDViewModel()
        {
            CreateHawkerCommand = new Command(async()=> await AddHawker());
            ClearTappedCommand = new Command(ClearInputs);
            DeleteHawkerCommand = new Command(async() => await DeleteHawker());
        }

        private void ClearInputs()
        {
            Name = null;
            AddressLine1 = null;
            AddressLine2 = null;
            Phone = null;
            Mobile = null;
        }

        public HawkerCRUDViewModel(int id)
        {
            IsEnabled = false;
            CurrentHawker = new Hawker();
            DeleteHawkerCommand = new Command(async () => await DeleteHawker());
            UpdateHawkerCommand = new Command(async () => await UpdateHawker());
            SaveTappedCommand = new Command(async () => await SaveHawker());
            GetHawkerCommand = new Command(async () => await GetHawker(id));
            ClearTappedCommand = new Command(async () => await ClearEdits(id));
            GetHawkerCommand.Execute(new Command(async () => await GetHawker(id)));
        }

        private async Task ClearEdits(int id)
        {
            await GetHawker(id);
        }

        private async Task SaveHawker()
        {
            await App.Database.SaveHawkerAsync(CurrentHawker);
            MessagingCenter.Send<HawkerCRUDViewModel>(this, "Data Updated");
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async Task GetHawker(int id)
        {
            CurrentHawker = await App.Database.GetHawkerAsync(id);
        }

        private async Task UpdateHawker()
        {
            IsEnabled = true;
        }

        private async Task DeleteHawker()
        {
            var result = await App.Current.MainPage.DisplayAlert($"Delete {CurrentHawker.Name}", $"Are you sure you want to delete {CurrentHawker.Name}", "Yes","No");
            if(result)
            {
                await App.Database.DeleteHawkerAsync(CurrentHawker);
                MessagingCenter.Send<HawkerCRUDViewModel>(this, "Data Updated");
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        private async Task AddHawker()
        {
            CurrentHawker = new Hawker();
            CurrentHawker.Name = Name;
            CurrentHawker.AddressLine1 = AddressLine1;
            CurrentHawker.AddressLine2 = AddressLine2;
            CurrentHawker.Phone = Phone;
            CurrentHawker.Mobile = Mobile;
            //var data = DependencyService.Get<IDataStore<Hawker>>();
            //data.AddItemAsync(CurrentHawker);
            await App.Database.SaveHawkerAsync(CurrentHawker);
            MessagingCenter.Send<HawkerCRUDViewModel>(this,"Data Updated");
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
