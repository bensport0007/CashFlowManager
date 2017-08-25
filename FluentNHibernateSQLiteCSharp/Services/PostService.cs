using System.Collections.Generic;
using FluentNHibernateSQLiteCSharp.Entities;
using FluentNHibernateSQLiteCSharp.Session;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public class PostService : IPostService
    {
        private readonly IQueryHelper<Post> _postQuerier;

        public PostService(IQueryHelper<Post> postQuerier)
        {
            _postQuerier = postQuerier;
        }

        public IList<Post> GetAllPosts()
        {
            return _postQuerier.GetAll();
        }
    }
}