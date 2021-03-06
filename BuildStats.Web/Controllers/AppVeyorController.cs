﻿using BuildStats.Core.BuildHistoryChart;
using BuildStats.Core.BuildHistoryChart.AppVeyor;
using BuildStats.Web.Config;

namespace BuildStats.Web.Controllers
{
    public sealed class AppVeyorController : BuildHistoryController
    {
        public AppVeyorController(IBuildStatistics buildStatistics, IChartConfig chartConfig) 
            : base(new AppVeyorFactory().CreateBuildHistoryClient(), buildStatistics, chartConfig)
        {
        }
    }
}