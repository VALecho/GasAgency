using GasAgency.ViewModels.ManageClients;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddClient : ContentPage
	{
		public AddClient ()
		{
			InitializeComponent ();
            this.BindingContext = new ClientCRUDViewModel();
		}
	}
}