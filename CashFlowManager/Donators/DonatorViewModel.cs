using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CashFlowManager.Properties;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Services;

namespace CashFlowManager.Donators
{
    public class DonatorViewModel : ViewerViewModelBase
    {
        private readonly IDonatorService _donatorService;
        private IList<Donator> _donatorsList;
        private IList<string> _filterProperties;
        private string _propertyToFilterOn;
        private string _valueToFilterOn;

        public DonatorViewModel(IDonatorService donatorService)
        {
            _donatorService = donatorService;
            DonatorsList = _donatorService.GetAllDonators();
            SaveChangesCommand = new RelayCommand(param => PersistData());
            _valueToFilterOn = _propertyToFilterOn = string.Empty;

            InitializeFilterCriterias();
        }

        public string Title
        {
            get { return Resources.DonatorViewModel_Title_Donators; }
        }

        public IList<Donator> DonatorsList
        {
            get
            {
                if (_propertyToFilterOn == string.Empty ||
                    _valueToFilterOn == string.Empty) return _donatorsList;

                var pinfo = typeof(Donator).GetProperty(_propertyToFilterOn);   //TODO:Filter better... use generics ?
                return _donatorsList.Where(x => pinfo.GetValue(x, null).ToString() == _valueToFilterOn).ToList();
            }
            set { _donatorsList = value; }
        }

        public IEnumerable<string> FilterList
        {
            get { return _filterProperties; }
        }

        public string PropertyToFilterOn
        {
            get { return _propertyToFilterOn; }
            set
            {
                _propertyToFilterOn = value;
                OnPropertyChanged(() => DonatorsList);
            }
        }

        public string ValueToFilterOn
        {
            get { return _valueToFilterOn; }
            set
            {
                _valueToFilterOn = value;
                OnPropertyChanged(() => DonatorsList);
            }
        }

        private void InitializeFilterCriterias()
        {
            _filterProperties = new List<string>();

            if (DonatorsList.Count > 0)
            {
                foreach (var property in DonatorsList.First().GetType().GetProperties())
                    _filterProperties.Add(property.Name);
            }
        }

        public ICommand SaveChangesCommand { get; set; }

        private void PersistData()
        {
            _donatorService.PersistDonators(DonatorsList);
        }
    }
}