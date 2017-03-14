using System.Collections.Generic;
using FluentNHibernateSQLiteCSharp.Entities;

namespace FluentNHibernateSQLiteCSharp.Services
{
    public interface IDonatorService
    {
        IList<Donator> GetAllDonators();
    }
}