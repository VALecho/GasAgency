using GasAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GasAgency.View
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            this.BindingContext = this;
            InitializeComponent();
            this.BindingContext = new DashboardPageViewModel();
        }
    }
}
