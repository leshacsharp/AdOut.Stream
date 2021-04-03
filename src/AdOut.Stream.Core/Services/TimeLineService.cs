using AdOut.Stream.Model.Config;
using AdOut.Stream.Model.Interfaces;
using AdOut.Stream.Model.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdOut.Stream.Core.Services
{
    public class TimeLineService : ITimeLineService
    {
        private readonly AdPointConfig _config;
        public TimeLineService(IOptions<AdPointConfig> options)
        {
            _config = options.Value;
        }

        public List<TimeAdBlock> GenerateTimeLine(List<PlanTime> plans, DateTime start, DateTime end)
        {
            if (end > start)
            {
                throw new ArgumentException("End can't be less start", nameof(end));
            }
             
            var timeBlocks = plans.SelectMany(p => GenerateTimeAdBlocks(p, start, end))
                                  .OrderBy(tb => tb.Start)
                                  .ToList();

            if (!timeBlocks.Any())
            {
                var gapForAllTime = new TimeAdBlock(_config.DefaultAdTitle, _config.DefaultAdPath, _config.StartWorking, _config.EndWorking, true);
                return new List<TimeAdBlock>() { gapForAllTime };
            }

            var timeLine = new List<TimeAdBlock>();
            var firstTimeBlock = timeBlocks.First();
            var lastTimeBlock = timeBlocks.Last();

            if (firstTimeBlock.Start != _config.StartWorking)
            {
                var gapForStart = new TimeAdBlock(_config.DefaultAdTitle, _config.DefaultAdPath, _config.StartWorking, firstTimeBlock.Start, true);
                timeLine.Add(gapForStart);
            }

            TimeAdBlock previousBlock = null;
            foreach (var currentBlock in timeBlocks)
            {
                if (previousBlock != null && previousBlock.End != currentBlock.Start)
                {
                    var gap = new TimeAdBlock(_config.DefaultAdTitle, _config.DefaultAdPath, previousBlock.End, currentBlock.Start, true);
                    timeLine.Add(gap);
                }
                timeLine.Add(currentBlock);
                previousBlock = currentBlock;
            }

            if (lastTimeBlock.End != _config.EndWorking)
            {
                var gapForEnd = new TimeAdBlock(_config.DefaultAdTitle, _config.DefaultAdPath, lastTimeBlock.End, _config.EndWorking, true);
                timeLine.Add(gapForEnd);
            }

            return timeLine;
        }

        public List<TimeAdBlock> GenerateTimeAdBlocks(PlanTime plan, DateTime start, DateTime end)
        {
            var timeBlocks = new List<TimeAdBlock>();
            var appropriateSchedules = plan.Schedules.Where(s => s.Dates.Any(d => d >= start && d <= end)).ToList();
            var orderedAds = plan.Ads.OrderBy(a => a.Order);

            var adsCircle = new LinkedList<AdPlanTime>(orderedAds);
            var currentAdNode = adsCircle.First;

            foreach (var schedule in appropriateSchedules)
            {
                foreach (var timeRange in schedule.TimeRanges)
                {
                    var timeBlock = new TimeAdBlock(currentAdNode.Value.Title, currentAdNode.Value.Path, timeRange.Start, timeRange.End);
                    currentAdNode = currentAdNode.Next ?? adsCircle.First;
                    timeBlocks.Add(timeBlock);
                }
            }

            return timeBlocks;
        }
    }
}
