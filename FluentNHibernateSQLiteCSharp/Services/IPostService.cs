using System.Collections.Generic;
using FluentNHibernateSQLiteCSharp.Entities;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public interface IPostService
    {
        IList<Post> GetAllPosts();
    }
}