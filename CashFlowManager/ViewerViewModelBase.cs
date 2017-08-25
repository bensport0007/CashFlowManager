using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using FluentNHibernateSQLiteCSharp.Services;
using FluentNHibernateSQLiteCSharp.Validations;

namespace CashFlowManager
{
    public class ViewerViewModelBase<T> : ViewModelBase
    {
        private readonly ICanPersistData _dataPersistenceService;
        private readonly ISearchFilter<T> _searchfilter;
        private readonly IValidationService _validationService;
        private IList<string> _filterProperties;
        private IEnumerable<T> _itemsList;
        private string _propertyToFilterOn;
        private string _valueToFilterOn;
        private IList<ValidationFailuresDto> _validationMessages;

        public ViewerViewModelBase(ICanPersistData dataPersistenceService, ISearchFilter<T> searchfilter,
            IValidationService validationService)
        {
            _dataPersistenceService = dataPersistenceService;
            _searchfilter = searchfilter;
            _validationService = validationService;
            _valueToFilterOn = _propertyToFilterOn = string.Empty;
            _itemsList = new List<T>();
            SaveChangesCommand = new RelayCommand(param => PersistData());
            InitializeFilterCriterias();
        }

        public IEnumerable<T> ItemsList
        {
            get { return _searchfilter.Filter(_propertyToFilterOn, _valueToFilterOn, _itemsList); }
            set { _itemsList = value; }
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
                OnPropertyChanged(() => ItemsList);
            }
        }

        public string ValueToFilterOn
        {
            get { return _valueToFilterOn; }
            set
            {
                _valueToFilterOn = value;
                OnPropertyChanged(() => ItemsList);
            }
        }

        public ICommand SaveChangesCommand { get; set; }

        public override string Title { get; set; }

        protected void InitializeFilterCriterias()
        {
            _filterProperties = new List<string>();

            foreach (var property in typeof(T).GetProperties())
                _filterProperties.Add(property.Name);
        }

        private static IEnumerable<object> ListAsObjectList(IEnumerable<T> objectsToPersist)
        {
            var ListAsObjects = new List<object>();
            foreach (var obj in objectsToPersist)
                ListAsObjects.Add(obj);
            return ListAsObjects;
        }

        public string ValidationMessages
        {
            get
            {
                foreach (var validationFailuresDto in _validationMessages)
                {
                    return validationFailuresDto.Message;
                }
                return string.Empty;
            }
        }

        protected void PersistData()
        {
            var objList = ListAsObjectList(ItemsList);
            var objectsToUpdateList = objList as object[] ?? objList.ToArray();

            _validationMessages = _validationService.ValidateObjectList(objectsToUpdateList);
            _dataPersistenceService.PersistObjectsList(objectsToUpdateList);
        }
    }
}