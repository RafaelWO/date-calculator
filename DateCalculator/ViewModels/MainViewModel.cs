using DateCalculator.BusinessClasses;
using DateCalculator.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DateCalculator.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private OutlookConnector outlookConnector = null;

        public MainViewModel()
        {
            StartDate = new DateTime(year: 2012, month: 10, day: 4);
            EndDate = DateTime.Now;
            
            //Anniversaries.Add(new Anniversary(3000, "Tage", new DateTime(2019, 5, 1)));
            //Anniversaries.Add(new Anniversary(3000, "Tage", DateTime.Now));
            //Anniversaries.Add(new Anniversary(3000, "Tage", DateTime.Now));
            //Anniversaries.Add(new Anniversary(3000, "Tage", DateTime.Now));

            var createOutlookConnector = Task.Factory.StartNew(() => { return new OutlookConnector(); })
                .ContinueWith(outlook => { outlookConnector = outlook.Result; });
            //outlookConnector = CreateOutlookConnector().Result;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public TimeSpan DateDiff { get; set; }
        public double DiffYears => DateDiff.TotalDays / 356.25;
        public double DiffDays => DateDiff.TotalDays;
        public double DiffHours => DateDiff.TotalHours;

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                CalcDateDiff();
            }
        }

        private DateTime _endDate;



        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                CalcDateDiff();
            }
        }

        private ObservableCollection<Anniversary> _anniversaries = new ObservableCollection<Anniversary>();
        public ObservableCollection<Anniversary> Anniversaries
        {
            get => _anniversaries;
            set
            {
                _anniversaries = value;
                OnPropertyChanged();
            }
        }

        private Anniversary _selectedAnniversary;
        public Anniversary SelectedAnniversary
        {
            get => _selectedAnniversary;
            set
            {
                _selectedAnniversary = value;
                OnPropertyChanged();
            }
        }

        public void CalcHighlights()
        {

        }
        
        public void AddAnniversary(string anniv)
        {
            char type = anniv[anniv.Length - 1];
            int typeLength = 0;

            if (char.IsLetter(type))
            {
                typeLength = 1;
            }

            if (!int.TryParse(anniv.Substring(0, anniv.Length - typeLength), out int value))
            {
                return;
            }

            TimeSpan anniversary;
            string annivType;
            switch (type)
            {
                case 'y':
                    anniversary = new TimeSpan(value*356,0,0,0,0);      // years
                    annivType = "Jahre";
                    break;
                case 'd':
                    anniversary = new TimeSpan(value,0,0,0);            // days
                    annivType = "Tage";
                    break;
                case 'h':
                    anniversary = new TimeSpan(value, 0, 0);            // hours
                    annivType = "Stunden";
                    break;
                default:
                    anniversary = new TimeSpan(value, 0, 0, 0);            // default: days
                    annivType = "Tage";
                    break;
            }

            var annivObj = new Anniversary(value, annivType, StartDate + anniversary);
            Anniversaries.Add(annivObj);
            OnPropertyChanged("Anniversaries");
        }

        public bool DeleteAnniversary()
        {
            var status = Anniversaries.Remove(SelectedAnniversary);
            OnPropertyChanged("Anniversaries");
            return status;
        }

        private void CalcDateDiff()
        {
            DateDiff = EndDate - StartDate;
            OnPropertyChanged("DiffYears");
            OnPropertyChanged("DiffDays");
            OnPropertyChanged("DiffHours");
        }


        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task<OutlookConnector> CreateOutlookConnector()
        {
            return await Task.Run(() => { return new OutlookConnector(); });
        }
    }
}
