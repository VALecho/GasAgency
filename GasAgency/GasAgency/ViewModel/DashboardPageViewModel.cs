using GasAgency.View;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModel
{
    class DashboardPageViewModel : BaseViewModel
    {
        public ICommand OfficeTappedCommand { get; set; }
        public ICommand HawkerTappedCommand { get; set; }
        public ICommand CreditTappedCommand { get; set; }
        public ICommand SummaryTappedCommand { get; set; }

        public DashboardPageViewModel()
        {
            OfficeTappedCommand = new Command(NavigateToOfficePage);
            HawkerTappedCommand = new Command(NavigateToHawkerSalesPage);
            CreditTappedCommand = new Command(NavigateToCreditPage);
            SummaryTappedCommand = new Command(NavigateToSummaryPage);
        }

        private void NavigateToSummaryPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new SummaryPage());
        }

        private void NavigateToCreditPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new CreditPage());
        }

        private void NavigateToHawkerSalesPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new HawkerSalesPage());
        }

        private void NavigateToOfficePage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new OfficePage());
        }
    }
}
