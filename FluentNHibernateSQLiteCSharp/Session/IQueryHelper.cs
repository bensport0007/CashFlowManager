using System;
using FluentNHibernateSQLiteCSharp.Entities;
using System.Collections.Generic;


namespace FluentNHibernateSQLiteCSharp.Session
{
    public interface IQueryHelper<TConcreteType> where TConcreteType : BaseEntity
    {
        IList<TConcreteType> GetAll();
        IList<TConcreteType> GetAllThatFitExpression(Func<TConcreteType, bool> seachCriteria);
    }
}
