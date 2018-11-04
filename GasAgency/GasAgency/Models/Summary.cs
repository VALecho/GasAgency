using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasAgency.Models
{
    public class Summary: ObservableObject
    {
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string summaryType;
        public string SummaryType
        {
            get { return summaryType; }
            set
            {
                summaryType = value;
                OnPropertyChanged("SummaryEvent");
            }
        }

        private int mediumCylinder;
        public int MediumCylinder
        {
            get { return mediumCylinder; }
            set
            {
                mediumCylinder = value;
                OnPropertyChanged("MediumCylinder");
            }
        }

        private int largeCylinder;
        public int LargeCylinder
        {
            get { return largeCylinder; }
            set
            {
                largeCylinder = value;
                OnPropertyChanged("LargeCylinder");
            }
        }

        private int smallCylinder;
        public int SmallCylinder
        {
            get { return smallCylinder; }
            set
            {
                smallCylinder = value;
                OnPropertyChanged("SmallCylinder");
            }
        }

        private DateTime summaryDate;

        public DateTime SummaryDate
        {
            get { return summaryDate; }
            set
            {
                summaryDate = value;
                OnPropertyChanged("SummaryDate");
            }
        }
    }
}
