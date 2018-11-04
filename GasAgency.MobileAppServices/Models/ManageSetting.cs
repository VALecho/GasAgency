using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasAgency.Models
{
    public class ManageSetting: ObservableObject
    {
        private string _imageURL;

        public string ImageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; }
        }

        private string _managedSetting;

        public string ManagedSetting
        {
            get { return _managedSetting; }
            set { _managedSetting = value; }
        }
    }
}
