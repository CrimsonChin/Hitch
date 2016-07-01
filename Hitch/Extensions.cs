using System;
using System.Collections.Generic;

namespace Hitch
{
    /// <summary>
    /// Extension class for IEnumerable of T designed to replicate the behaviour of LINQ.
    /// This is not a complete linq replacement.  Just a bit of fun.
    /// </summary>
    public static class Extensions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        public static IList<T> ToList<T>(this IEnumerable<T> source)
        {
            IList<T> list = new List<T>();
            foreach (var item in source)
            {
                list.Add(item);
            }

            return list;
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                return item;
            }

            return default(T);
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }

            return default(T);
        }
    }
}
