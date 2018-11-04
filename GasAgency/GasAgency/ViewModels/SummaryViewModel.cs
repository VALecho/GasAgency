using GasAgency.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GasAgency.ViewModels
{
    public class SummaryViewModel: BaseViewModel
    {
        public ObservableCollection<Summary> SummaryReport { get; set; }

        public SummaryViewModel()
        {
            SummaryReport = new ObservableCollection<Summary>();
            SummaryReport.Add(new Summary { SummaryType = "Opening Stock", MediumCylinder = 200, LargeCylinder = 200, SmallCylinder = 200 });
            SummaryReport.Add(new Summary { SummaryType = "From HPCL", MediumCylinder = 200, LargeCylinder = 200, SmallCylinder = 200 });
            SummaryReport.Add(new Summary { SummaryType = "Total", MediumCylinder = 200, LargeCylinder = 200, SmallCylinder = 200 });
            SummaryReport.Add(new Summary { SummaryType = "To Refill", MediumCylinder = 200, LargeCylinder = 200, SmallCylinder = 200 });
            SummaryReport.Add(new Summary { SummaryType = "To New", MediumCylinder = 200, LargeCylinder = 200, SmallCylinder = 200 });
            SummaryReport.Add(new Summary { SummaryType = "To Additional", MediumCylinder = 200, LargeCylinder = 200, SmallCylinder = 200 });
        }
    }
}
