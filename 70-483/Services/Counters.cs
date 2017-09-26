using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Services
{
    public static class Counters
    {
        public static void CreateCounters()
        {
            if (!PerformanceCounterCategory.Exists("Kanters"))
            {
                var counters = new CounterCreationDataCollection();

                var ccdCounter1 = new CounterCreationData
                {
                    CounterName = "First",
                    CounterType = PerformanceCounterType.AverageTimer32
                };
                counters.Add(ccdCounter1);
                var ccdCounter2 = new CounterCreationData
                {
                    CounterName = "Second",
                    CounterType = PerformanceCounterType.AverageBase
                };
                counters.Add(ccdCounter2);

                PerformanceCounterCategory.Create(
                    "Kanters",
                    "Desc",
                    PerformanceCounterCategoryType.MultiInstance,
                    counters);
            }
        }

        public static void CreateCounters2()
        {
            if (!PerformanceCounterCategory.Exists("Kanters"))
            {
                var counters = new CounterCreationDataCollection();

                var ccdCounter1 = new CounterCreationData
                {
                    CounterName = "First",
                    CounterType = PerformanceCounterType.SampleFraction
                };
                counters.Add(ccdCounter1);
                var ccdCounter2 = new CounterCreationData
                {
                    CounterName = "Second",
                    CounterType = PerformanceCounterType.SampleBase
                };
                counters.Add(ccdCounter2);

                PerformanceCounterCategory.Create(
                    "Kanters",
                    "Desc",
                    PerformanceCounterCategoryType.MultiInstance,
                    counters);
            }
        }
    }
}
