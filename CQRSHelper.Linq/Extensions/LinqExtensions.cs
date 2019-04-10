using CQRSHelper.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CQRSHelper.Linq.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<TItem> Filter<TEntity, TItem>(this IQueryable<TEntity> queryalbe, IQuery<TEntity, TItem> query) where TEntity : class where TItem : class
        {
            if (query.SelectExpression == null) throw new InvalidOperationException("The select property is mandatory on o querie objects!");

            if (query.WhereExpression != null)
                queryalbe = queryalbe.Where(query.WhereExpression);

            return queryalbe.Select(query.SelectExpression);
        }

        public static IQueryable<TItem> Filter<TEntity, TItem>(this DbContext context, IQuery<TEntity, TItem> query) where TEntity : class where TItem : class
            => context.Set<TEntity>().Filter(query);
    }

}
