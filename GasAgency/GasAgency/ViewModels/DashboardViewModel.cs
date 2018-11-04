using GasAgency.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public ICommand CompanyTabTapCommand { get; set; }
        public ICommand HawkersTabTapCommand { get; set; }

        public ICommand CreditTabTapCommand { get; set; }

        public ICommand SummaryTabTapCommand { get; set; }

        public ICommand AppSettingsTappedCommand { get; set; }

        public DashboardViewModel()
        {
            CompanyTabTapCommand = new Command(NavigateToCompanyPage);
            HawkersTabTapCommand = new Command(NavigateToHawkersPage);
            CreditTabTapCommand = new Command(NavigateToCreditsPage);
            SummaryTabTapCommand = new Command(NavigateToSummaryPage);
            AppSettingsTappedCommand = new Command(NavigateToSettingsPage); 
        }

        private void NavigateToSettingsPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new ManageSettings());
        }

        private void NavigateToSummaryPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new DailySummary());
        }

        private void NavigateToCreditsPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new CreditDetails());
        }

        private void NavigateToHawkersPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new HawkerSales());
        }

        private void NavigateToCompanyPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Company());
        }
    }
}
