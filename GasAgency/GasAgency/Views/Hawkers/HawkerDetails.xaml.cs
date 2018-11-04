using GasAgency.Models;
using GasAgency.ViewModels.ManageHawkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.Views.Hawkers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HawkerDetails : ContentPage
	{
		public HawkerDetails (int id)
		{
			InitializeComponent ();
            BindingContext = new HawkerCRUDViewModel(id);
		}
	}
}