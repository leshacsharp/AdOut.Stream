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

        public List<TimeBlock> GenerateTimeLine(List<PlanTime> plans, DateTime forDate, TimeSpan fromTime)
        {
            var timeBlocks = plans.SelectMany(p => GenerateTimeAdBlocks(p, forDate, fromTime)).ToList();
            var filledTimeLine = FillTimeLine(timeBlocks, fromTime, _config.EndWorking);
            return filledTimeLine;
        }
   
        //for not gaps the startTime is CurrentTimeBlock.End, for gaps the startTimec is a day local time
        public List<TimeBlock> MergeTimeLine(List<TimeBlock> timeLine, PlanTime newPlan, DateTime forDate, TimeSpan fromTime)
        {
            var cleanTimeLineBlocks = timeLine.Where(b => !b.Gap);
            var planTimeBlocks = GenerateTimeAdBlocks(newPlan, forDate, fromTime);
            var mergedTimeBlocks = cleanTimeLineBlocks.Concat(planTimeBlocks).ToList();
            var filledTimeLine = FillTimeLine(mergedTimeBlocks, fromTime, _config.EndWorking);   
            return filledTimeLine;
        }

        private List<TimeBlock> FillTimeLine(List<TimeBlock> timeBlocks, TimeSpan startTimeLine, TimeSpan endTimeLine)
        {
            if (!timeBlocks.Any())
            {
                var gapForAllTime = new TimeBlock(_config.DefaultAdTitle, _config.DefaultAdPath, _config.DefaultAdType, startTimeLine, endTimeLine, true);
                return new List<TimeBlock>() { gapForAllTime };
            }

            var timeLine = new List<TimeBlock>();
            var orderedTimeBlocks = timeBlocks.OrderBy(t => t.Start).ToList();
            var firstTimeBlock = orderedTimeBlocks.First();
            var lastTimeBlock = orderedTimeBlocks.Last();

            if (firstTimeBlock.Start > startTimeLine)
            {
                var gapForStart = new TimeBlock(_config.DefaultAdTitle, _config.DefaultAdPath, _config.DefaultAdType, startTimeLine, firstTimeBlock.Start, true);
                timeLine.Add(gapForStart);
            }

            var timeBlocksWithGaps = IncludeGapsBetweenTimeBlocks(orderedTimeBlocks);
            timeLine.AddRange(timeBlocksWithGaps);

            if (lastTimeBlock.End < endTimeLine)
            {
                var gapForEnd = new TimeBlock(_config.DefaultAdTitle, _config.DefaultAdPath, _config.DefaultAdType, lastTimeBlock.End, endTimeLine, true);
                timeLine.Add(gapForEnd);
            }

            return timeLine;
        }

        private List<TimeBlock> IncludeGapsBetweenTimeBlocks(List<TimeBlock> timeBlocks)
        {
            var timeBlocksWithGaps = new List<TimeBlock>();
            TimeBlock previousBlock = null;

            foreach (var currentBlock in timeBlocks)
            {
                if (previousBlock != null && previousBlock.End != currentBlock.Start)
                {
                    var gap = new TimeBlock(_config.DefaultAdTitle, _config.DefaultAdPath, _config.DefaultAdType, previousBlock.End, currentBlock.Start, true);
                    timeBlocksWithGaps.Add(gap);
                }
                timeBlocksWithGaps.Add(currentBlock);
                previousBlock = currentBlock;
            }

            return timeBlocksWithGaps;
        }

        private List<TimeBlock> GenerateTimeAdBlocks(PlanTime plan, DateTime forDate, TimeSpan fromTime)
        {
            var timeBlocks = new List<TimeBlock>();
            var orderedAds = plan.Ads.OrderBy(a => a.Order);
            var adsCircle = new LinkedList<AdPlanTime>(orderedAds);
            var currentAdNode = adsCircle.First;

            var appropriateTimeRanges = plan.Schedules.Where(s => s.Dates.Any(d => d.Date == forDate.Date))
                .SelectMany(s => s.TimeRanges.Where(t => t.Start >= fromTime))
                .OrderBy(t => t.Start)
                .ToList();    

            foreach (var timeRange in appropriateTimeRanges)
            {
                var timeBlockAd = currentAdNode.Value;
                var timeBlock = new TimeBlock(timeBlockAd.Title, timeBlockAd.Path, timeBlockAd.ContentType, timeRange.Start, timeRange.End);
                currentAdNode = currentAdNode.Next ?? adsCircle.First;
                timeBlocks.Add(timeBlock);
            }
            
            return timeBlocks;
        }
    }
}
