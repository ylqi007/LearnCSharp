namespace ExtensionMethodsDemo.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source)
        where T : class
    {
        foreach (T? item in source)
        {
            if (item is not null)
            {
                yield return item;
            }
        }
    }

    public static string JoinAsText<T>(this IEnumerable<T> source, string separator = ", ")
    {
        return string.Join(separator, source);
    }

    public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, bool> stopCondition)
    {
        foreach (T item in source)
        {
            if (stopCondition(item))
            {
                yield break;
            }

            yield return item;
        }
    }
}
