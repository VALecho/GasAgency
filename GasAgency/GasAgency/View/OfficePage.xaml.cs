using GasAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OfficePage : ContentPage
	{
		public OfficePage ()
		{
			InitializeComponent ();
            this.BindingContext = new OfficePageViewModel();
		}

        private void SfTabView_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        {

        }
    }
}