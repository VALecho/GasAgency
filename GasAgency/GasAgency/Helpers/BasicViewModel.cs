using GasAgency.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GasAgency.Helpers
{
    public class BasicViewModel<T>: BaseViewModel
    {
        public AzureDataStore<T> DataStore => DependencyService.Get<AzureDataStore<T>>();
    }
}