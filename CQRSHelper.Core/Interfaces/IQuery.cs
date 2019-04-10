using System;
using System.Linq.Expressions;

namespace CQRSHelper.Core.Interfaces
{
    public interface IQuery<TEntity, TItem> where TEntity : class where TItem : class
    {
        Expression<Func<TEntity, bool>> WhereExpression { get; }

        Expression<Func<TEntity, TItem>> SelectExpression { get; }
    }
}
