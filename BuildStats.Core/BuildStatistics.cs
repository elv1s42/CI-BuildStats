﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildStats.Core
{
    public sealed class BuildStatistics : IBuildStatistics
    {
        public TimeSpan GetLongestBuildTime(IList<Build> builds)
        {
            return builds.Where(b => b.Status != BuildStatus.Cancelled).Max(b => b.TotalTime);
        }

        public TimeSpan GetShortestBuildTime(IList<Build> builds)
        {
            return builds.Where(b => b.Status != BuildStatus.Cancelled).Min(b => b.TotalTime);
        }

        public TimeSpan GetAverageBuildTime(IList<Build> builds)
        {
            return TimeSpan.FromMilliseconds(builds.Where(b => b.Status != BuildStatus.Cancelled).Average(b => b.TotalTime.TotalMilliseconds));
        }
    }
}