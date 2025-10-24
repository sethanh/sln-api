using System.Linq.Expressions;
using Sln.Shared.Contract.Models;

namespace Sln.Shared.Contract.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> TryOrderByIdDescending<T>(
        this IQueryable<T> queryable,
        ScrollPaginationRequest scroll)
        {
            var type = typeof(T);
            var idProp = type.GetProperty("Id");
            if (idProp == null)
                return queryable;
            var param = Expression.Parameter(type, "q");
            var idAccess = Expression.MakeMemberAccess(param, idProp);

            if (scroll.BeforeId.HasValue && idProp.PropertyType == typeof(Guid))
            {
                var beforeConst = Expression.Constant(scroll.BeforeId.Value, typeof(Guid));
                var compareTo = typeof(Guid).GetMethod(nameof(Guid.CompareTo), new[] { typeof(Guid) })!;
                var callCompare = Expression.Call(idAccess, compareTo, beforeConst);
                var lessThanZero = Expression.LessThan(callCompare, Expression.Constant(0));

                var whereLambda = Expression.Lambda<Func<T, bool>>(lessThanZero, param);
                queryable = queryable.Where(whereLambda);
            }

            var keySelector = Expression.Lambda(idAccess, param);
            var orderByDescMethod = typeof(Queryable).GetMethods()
                .First(m => m.Name == nameof(Queryable.OrderByDescending)
                            && m.IsGenericMethodDefinition
                            && m.GetParameters().Length == 2)
                .MakeGenericMethod(type, idProp.PropertyType);

            return (IQueryable<T>)orderByDescMethod.Invoke(null, [queryable, keySelector])!;
        }
    }
}