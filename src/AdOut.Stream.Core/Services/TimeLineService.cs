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

        public List<TimeBlock> GenerateTimeLine(List<PlanTime> plans, DateTime date)
        {
            var timeBlocks = plans.SelectMany(p => GenerateTimeAdBlocks(p, date))
                                  .OrderBy(b => b.Start)
                                  .ToList();

            if (!timeBlocks.Any())
            {
                var gapForAllTime = new TimeBlock(_config.DefaultAdTitle, _config.DefaultAdPath, _config.StartWorking, _config.EndWorking, true);
                return new List<TimeBlock>() { gapForAllTime };
            }

            var timeLine = new List<TimeBlock>();
            var firstTimeBlock = timeBlocks.First();
            var lastTimeBlock = timeBlocks.Last();

            if (firstTimeBlock.Start != _config.StartWorking)
            {
                var gapForStart = new TimeBlock(_config.DefaultAdTitle, _config.DefaultAdPath, _config.StartWorking, firstTimeBlock.Start, true);
                timeLine.Add(gapForStart);
            }

            var timeBlocksWithGaps = IncludeGapsBetweenTimeBlocks(timeBlocks);
            timeLine.AddRange(timeBlocksWithGaps);

            if (lastTimeBlock.End != _config.EndWorking)
            {
                var gapForEnd = new TimeBlock(_config.DefaultAdTitle, _config.DefaultAdPath, lastTimeBlock.End, _config.EndWorking, true);
                timeLine.Add(gapForEnd);
            }

            return timeLine;
        }

        //for not gaps the startTime is CurrentTimeBlock.End, for gaps the startTimec is a day local time
        public List<TimeBlock> MergeTimeLine(List<TimeBlock> timeLine, PlanTime newPlan, DateTime date, TimeSpan startTime)
        {
            var cleanTimeLineBlocks = timeLine.Where(b => !b.Gap);
            var planTimeBlocks = GenerateTimeAdBlocks(newPlan, date).Where(b => b.Start >= startTime);
            var mergedTimeBlocks = cleanTimeLineBlocks.Concat(planTimeBlocks).OrderBy(b => b.Start).ToList();

            if (!mergedTimeBlocks.Any())
            {
                return timeLine;
            }

            var mergedTimeLine = new List<TimeBlock>();
            var firstTimeBlock = mergedTimeBlocks.First();
            var lastTimeBlock = mergedTimeBlocks.Last();

            if (firstTimeBlock.Start != startTime)
            {
                var gapForStart = new TimeBlock(_config.DefaultAdTitle, _config.DefaultAdPath, startTime, firstTimeBlock.Start, true);
                mergedTimeLine.Add(gapForStart);
            }

            var timeBlocksWithGaps = IncludeGapsBetweenTimeBlocks(mergedTimeBlocks);
            mergedTimeLine.AddRange(timeBlocksWithGaps);

            if (lastTimeBlock.End != _config.EndWorking)
            {
                var gapForEnd = new TimeBlock(_config.DefaultAdTitle, _config.DefaultAdPath, lastTimeBlock.End, _config.EndWorking, true);
                timeLine.Add(gapForEnd);
            }

            return mergedTimeLine;
        }

        private List<TimeBlock> IncludeGapsBetweenTimeBlocks(List<TimeBlock> timeBlocks)
        {
            var timeBlocksWithGaps = new List<TimeBlock>();
            TimeBlock previousBlock = null;

            foreach (var currentBlock in timeBlocks)
            {
                if (previousBlock != null && previousBlock.End != currentBlock.Start)
                {
                    var gap = new TimeBlock(_config.DefaultAdTitle, _config.DefaultAdPath, previousBlock.End, currentBlock.Start, true);
                    timeBlocksWithGaps.Add(gap);
                }
                timeBlocksWithGaps.Add(currentBlock);
                previousBlock = currentBlock;
            }

            return timeBlocksWithGaps;
        }

        private List<TimeBlock> GenerateTimeAdBlocks(PlanTime plan, DateTime date)
        {
            var timeBlocks = new List<TimeBlock>();
            var appropriateSchedules = plan.Schedules.Where(s => s.Dates.Any(d => d == date.Date)).ToList();
            var orderedAds = plan.Ads.OrderBy(a => a.Order);

            var adsCircle = new LinkedList<AdPlanTime>(orderedAds);
            var currentAdNode = adsCircle.First;

            foreach (var schedule in appropriateSchedules)
            {
                foreach (var timeRange in schedule.TimeRanges)
                {
                    var timeBlock = new TimeBlock(currentAdNode.Value.Title, currentAdNode.Value.Path, timeRange.Start, timeRange.End);
                    currentAdNode = currentAdNode.Next ?? adsCircle.First;
                    timeBlocks.Add(timeBlock);
                }
            }

            return timeBlocks;
        }
    }
}
