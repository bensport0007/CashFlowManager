using CashFlowManager.Properties;
using FluentNHibernateSQLiteCSharp.Services;

namespace CashFlowManager.Posts
{
    public class PostsViewerViewModel : ViewerViewModelBase<FluentNHibernateSQLiteCSharp.Entities.Post>
    {
        public PostsViewerViewModel(ICanPersistData dataPersistenceService,
            ISearchFilter<FluentNHibernateSQLiteCSharp.Entities.Post> searchfilter,
            IPostService postService, IValidationService validationService)
            : base(dataPersistenceService, searchfilter, validationService)
        {
            ItemsList = postService.GetAllPosts();
        }

        public override string Title => Resources.TransactionViewModel_Title_Transaction;
    }
}