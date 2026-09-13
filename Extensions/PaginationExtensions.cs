namespace Digital_Services_BD.Extensions;

public static class PaginationExtensions
{
    // Catalog routes use zero-based pages; keep this distinct from one-based search pages.
    public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int page, int size)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(size);
        var skip = Math.Min((long)Math.Max(0, page) * size, int.MaxValue);
        return source.Skip((int)skip).Take(size);
    }
}
