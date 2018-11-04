using GasAgency.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels
{
    public class ExpenseViewModel: BaseViewModel
    {
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private Expense _currentExpense;

        public Expense CurrentExpense
        {
            get { return _currentExpense; }
            set { _currentExpense = value; }
        }


        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private double _cost;
        public double Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                OnPropertyChanged("Cost");
            }
        }

        public ExpenseViewModel()
        {
            try
            {
                CancelCommand = new Command(CancelSaveNewExpense);
                SaveCommand = new Command(async()=>await SaveNewExpense());
                
            }
            catch (Exception ex)
            {
                var t = ex.Message;
                throw;
            }
        }        

        private async Task SaveNewExpense()
        {
            CurrentExpense = new Expense();
            CurrentExpense.Cost = Cost;
            CurrentExpense.Description = Description;
            CurrentExpense.TimeStamp = DateTime.Now.Date.Date.Date;
            await App.Database.SaveExpenseAsync(CurrentExpense);
            MessagingCenter.Send<ExpenseViewModel>(this,"Data Updated");
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void CancelSaveNewExpense(object obj)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
