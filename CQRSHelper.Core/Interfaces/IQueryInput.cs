using System;
using System.Linq.Expressions;

namespace CQRSHelper.Core.Interfaces
{
    public interface IQueryInput<TEntity, TItem> where TEntity : class where TItem : class
    {
        Expression<Func<TEntity, bool>> GetWhereExpression();

        Expression<Func<TEntity, TItem>> GetSelectExpression();
    }
}
