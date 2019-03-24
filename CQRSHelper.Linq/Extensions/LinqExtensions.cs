using CQRSHelper.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CQRSHelper.Linq.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<TItem> Filter<TEntity, TItem>(this IQueryable<TEntity> queryalbe, IQueryInput<TEntity, TItem> query) where TEntity : class where TItem : class
            => queryalbe.Where(query.GetWhereExpression()).Select(query.GetSelectExpression());

        public static IQueryable<TItem> Filter<TEntity, TItem>(this DbContext context, IQueryInput<TEntity, TItem> query) where TEntity : class where TItem : class
            => context.Set<TEntity>().Filter(query);
    }

}
