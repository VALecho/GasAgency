using GasAgency.Models;
using GasAgency.Views;
using GasAgency.Views.Hawkers;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels.ManageHawkers
{
    class HawkersListViewModel : BaseViewModel
    {
        public ICommand AddHawkerTappedCommand { get; set; }

        public ICommand DeleteHawkerTappedCommand { get; set; }

        public  ICommand ListItemTappedCommand { get; set; }

        private ObservableCollection<Hawker> _Hawkers;
        public ObservableCollection<Hawker> Hawkers
        {
            get { return _Hawkers; }
            set
            {
                _Hawkers = value;
                OnPropertyChanged("Hawkers");
            }
        }

        private Hawker _selectedHawker;

        public Hawker SelectedHawker
        {
            get { return _selectedHawker; }
            set
            {
                _selectedHawker = value;
                OnPropertyChanged("SelectedHawker");
            }
        }

        public HawkersListViewModel()
        {
            Hawkers = new ObservableCollection<Hawker>();
            MessagingCenter.Subscribe<HawkerCRUDViewModel>(this,"Data Updated", async (sender)=>
            {
                Hawkers = new ObservableCollection<Hawker>(await App.Database.GetHawkersAsync());
            });
            AddHawkerTappedCommand = new Command(NavigateToAddHawker);
            ListItemTappedCommand = new Command(NavigateToHawkerDetailsPage);
            GetHawkers();
        }

        private void NavigateToHawkerDetailsPage(object obj)
        {
            //MessagingCenter.Send<this>(this, );
            App.Current.MainPage.Navigation.PushAsync(new HawkerDetails(SelectedHawker.Id));
        }

        private void NavigateToAddHawker(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new AddHawker());
        }

        private async Task GetHawkers()
        {
            Hawkers = new ObservableCollection<Hawker>(await App.Database.GetHawkersAsync());
        }
    }
}
