using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Framework.Utility
{
    public static class EnumerableExtensions
    {
        public class LambdaComparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> _expression;

            public LambdaComparer(Func<T, T, bool> expression)
            {
                _expression = expression;
            }

            public bool Equals(T x, T y)
            {
                return _expression(x, y);
            }

            public int GetHashCode(T obj)
            {
                return 0;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> enumerable, IEnumerable<T> second, Func<T, T, bool> expression)
        {
            return enumerable.Except(second, new LambdaComparer<T>(expression));
        }

        public static IEnumerable<TResult> Except<TResult, TOther, TKey>(
            this IEnumerable<TResult> enumerable,
            IEnumerable<TOther> second,
            Func<TResult, TKey> keySelector,
            Func<TOther, TKey> secondKeySelector)
        {
            return enumerable.Except(
                second,
                keySelector,
                secondKeySelector,
                keySelector,
                secondKeySelector);
        }
        
        public static IEnumerable<TResult> Except<TResult, TOther, TKey, TComparer>(
            this IEnumerable<TResult> enumerable,
            IEnumerable<TOther> second,
            Func<TResult, TKey> keySelector,
            Func<TOther, TKey> secondKeySelector,
            Func<TResult, TComparer> comparerSelector,
            Func<TOther, TComparer> secondComparerSelector)
        {
            var valuesByKey = enumerable
                .Where(i => !keySelector(i).Equals(default(TKey)))
                .ToDictionary(i => keySelector(i), i => i);
            var comparersByKey1 = valuesByKey.ToDictionary(kvp => kvp.Key, kvp => comparerSelector(kvp.Value));
            var comparersByKey2 = second
                .Where(i => !secondKeySelector(i).Equals(default(TKey)))
                .ToDictionary(i => secondKeySelector(i), i => secondComparerSelector(i));
            var difference = comparersByKey1.Except(comparersByKey2, (kvp1, kvp2) => kvp1.Key.Equals(kvp2.Key));
            var result = difference.Select(kvp => valuesByKey[kvp.Key]);
            return result;
        }
    }
}
