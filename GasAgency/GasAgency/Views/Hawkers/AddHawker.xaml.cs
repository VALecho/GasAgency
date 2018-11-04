using GasAgency.ViewModels.ManageHawkers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddHawker : ContentPage
	{
		public AddHawker ()
		{
			InitializeComponent ();
            this.BindingContext = new HawkerCRUDViewModel();
		}
	}
}