using GasAgency.Models;
using GasAgency.ViewModels.ManageClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.Views.Clients
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClientDetails : ContentPage
	{
		public ClientDetails (int id)
		{
			InitializeComponent ();
            BindingContext = new ClientCRUDViewModel(id);
		}
	}
}