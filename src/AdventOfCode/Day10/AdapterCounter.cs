﻿using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    public static class AdapterCounter
    {
        public static (int count1JoltDifferences, int count3JoltDifferences) CountJoltDifferences(
            this List<int> adaptersJoltages)
        {
            var count1JoltDifferences = 0;
            var count3JoltDifferences = 0;
            var chainedAdapters = adaptersJoltages.Zip(
                adaptersJoltages.Skip(1),
                (fromAdapter, toAdapter) => (fromAdapter, toAdapter));

            foreach (var pluggedAdapters in chainedAdapters)
                switch (pluggedAdapters.toAdapter - pluggedAdapters.fromAdapter)
                {
                    case 1:
                        count1JoltDifferences++;
                        break;
                    case 3:
                        count3JoltDifferences++;
                        break;
                }

            return (count1JoltDifferences, count3JoltDifferences);
        }

        public static long CountTotalNumberOfArrangements(this IEnumerable<int> adaptersJoltages)
            => adaptersJoltages.CountTotalNumberOfArrangements(new Dictionary<int, long>());

        private static long CountTotalNumberOfArrangements(
            this IEnumerable<int> adaptersJoltages,
            IDictionary<int, long> memoizedSum)
        {
            if (adaptersJoltages.Count() == 1)
                return 1;

            if (memoizedSum.ContainsKey(adaptersJoltages.First()))
                return memoizedSum[adaptersJoltages.First()];

            var sum = adaptersJoltages
                .Select((adapterJoltage, index) => (adapterJoltage, index))
                .Skip(1)
                .TakeWhile(item => item.adapterJoltage - adaptersJoltages.First() <= 3)
                .Sum(
                    item => CountTotalNumberOfArrangements(
                        adaptersJoltages.Skip(item.index),
                        memoizedSum));

            memoizedSum.Add(adaptersJoltages.First(), sum);

            return sum;
        }
    }
}