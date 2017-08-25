using CashFlowManager.Properties;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Services;

namespace CashFlowManager.Donators
{
    public class DonatorsViewerViewModel : ViewerViewModelBase<Donator>
    {
        public DonatorsViewerViewModel(IDonatorService donatorService,
            ICanPersistData dataPersistenceService,
            ISearchFilter<Donator> searchFilter,
            IValidationService validationService)
            : base(dataPersistenceService, searchFilter, validationService)
        {
            ItemsList = donatorService.GetAllDonators();
        }

        public override string Title
        {
            get { return Resources.DonatorViewModel_Title_Donators; }
        }
    }
}