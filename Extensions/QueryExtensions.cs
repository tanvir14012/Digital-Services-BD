using System.Linq.Expressions;

namespace Digital_Services_BD.Extensions;

public static class QueryExtensions
{
    public static IQueryable<T> WhereContainsAny<T>(this IQueryable<T> query,
        Expression<Func<T, string>> field, IEnumerable<string> terms)
    {
        Expression body = Expression.Constant(false);
        var normalized = Expression.Call(field.Body, nameof(string.ToLower), Type.EmptyTypes);
        foreach (var term in terms)
        {
            var contains = Expression.Call(normalized, nameof(string.Contains), Type.EmptyTypes, Expression.Constant(term));
            body = Expression.OrElse(body, contains);
        }
        return query.Where(Expression.Lambda<Func<T, bool>>(body, field.Parameters));
    }
}
