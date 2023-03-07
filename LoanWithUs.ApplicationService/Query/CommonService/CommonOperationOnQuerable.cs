using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LoanWithUs.ApplicationService.Query
{
    public static class CommonQueryableOperation
    {
        public static Task<List<T>> DoCommonPagin<T>(this IQueryable<T> query, PagingContract contract)
        {
            if (string.IsNullOrEmpty(contract.Sort))
            {
                contract.Sort = "Desc";
            }

            if (contract.Sort.ToLower() == "desc")
            {
                query = query.OrderByDescending(ToLambda<T>(contract.Order));
            }
            else
            {
                query = query.OrderBy(ToLambda<T>(contract.Order));
            }

            return query.Skip((contract.PageSize) * (contract.PageNumber - 1))
                .Take(contract.PageSize)
                .ToListAsync();
        }


        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            MemberExpression property;
            try
            {
                 property = Expression.Property(parameter, propertyName);
             
            }
            catch (Exception)
            {
                property = Expression.Property(parameter, "Id");
            }
            var propAsObject = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }

    }
}
