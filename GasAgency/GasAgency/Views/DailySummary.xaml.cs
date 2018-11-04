using GasAgency.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DailySummary : ContentPage
	{
		public DailySummary ()
		{
			InitializeComponent ();
            this.BindingContext = new SummaryViewModel();
		}
	}
}