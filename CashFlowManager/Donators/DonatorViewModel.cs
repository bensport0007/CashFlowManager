using CashFlowManager.Properties;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Services;

namespace CashFlowManager.Donators
{
    public class DonatorViewModel : ViewerViewModelBase<Donator>
    {
        public DonatorViewModel(IDonatorService donatorService, ICanPersistData dataPersistenceService, ISearchFilter<Donator> searchFilter)
            : base(dataPersistenceService, searchFilter)
        {
            ItemsList = donatorService.GetAllDonators();
        }

        public override string Title
        {
            get { return Resources.DonatorViewModel_Title_Donators; }
        }
    }
}