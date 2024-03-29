﻿using System.Diagnostics;

namespace Blazor.NavigationLocker
{
    [DebuggerDisplay("{TemplateText}")]
    public class RouteTemplate
    {
        public RouteTemplate(string templateText, TemplateSegment[] segments)
        {
            TemplateText = templateText;
            Segments = segments;

            for (var i = 0; i < segments.Length; i++)
            {
                var segment = segments[i];
                if (segment.IsOptional)
                {
                    OptionalSegmentsCount++;
                }
                if (segment.IsCatchAll)
                {
                    ContainsCatchAllSegment = true;
                }
            }
        }

        public string TemplateText { get; }

        public TemplateSegment[] Segments { get; }

        public int OptionalSegmentsCount { get; }

        public bool ContainsCatchAllSegment { get; }
    }
}
