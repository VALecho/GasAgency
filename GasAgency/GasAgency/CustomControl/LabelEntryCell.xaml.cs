using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.CustomControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LabelEntryCell : Grid
	{
		public LabelEntryCell ()
		{
			InitializeComponent ();
            BindingContext = this;
		}

        private static readonly BindableProperty LabelTextProperty = 
            BindableProperty.Create("LabelText", typeof(string), typeof(LabelEntryCell),null);

        private static readonly BindableProperty EntryTextProperty =
            BindableProperty.Create("EntryText", typeof(string), typeof(LabelEntryCell), null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public string EntryText
        {
            get { return (string)GetValue(EntryTextProperty); }
            set { SetValue(EntryTextProperty, value); }
        }
    }
}