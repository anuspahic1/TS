
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using Entities.Models;
using System.Linq.Expressions;

public static class IQueryableExtensions
{
    public static IQueryable<T> Sort<T>(this IQueryable<T> source, string? orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return source;

        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        var orderQueryBuilder = new System.Text.StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, System.StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
                continue;

            var direction = param.EndsWith(" desc") ? "descending" : "ascending";
            orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

        if (string.IsNullOrWhiteSpace(orderQuery))
            return source;

        return source.OrderBy(orderQuery);
    }
    public static IQueryable<T> Search<T>(this IQueryable<T> source, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return source;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        var parameter = Expression.Parameter(typeof(T), "x");
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                  .Where(p => p.PropertyType == typeof(string));

        Expression? orExpression = null;

        foreach (var property in properties)
        {
            var propertyAccess = Expression.Property(parameter, property);

            // Coalesce null string properties to empty string before calling ToLower()
            var coalesced = Expression.Coalesce(propertyAccess, Expression.Constant(string.Empty, typeof(string)));
            var toLowerCall = Expression.Call(coalesced, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes)!);

            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var searchTermExpression = Expression.Constant(lowerCaseTerm, typeof(string));
            var containsCall = Expression.Call(toLowerCall, containsMethod!, searchTermExpression);

            if (orExpression == null)
            {
                orExpression = containsCall;
            }
            else
            {
                orExpression = Expression.OrElse(orExpression, containsCall);
            }
        }

        if (orExpression == null)
            return source;

        var lambda = Expression.Lambda<Func<T, bool>>(orExpression, parameter);
        return source.Where(lambda);
    }

}