using System.Diagnostics;

namespace Blazor.NavigationLocker
{
    [DebuggerDisplay("Handler = {Handler}, Template = {Template}")]
    public class RouteEntry
    {
        public RouteTemplate Template { get; }
        public List<string>? UnusedRouteParameterNames { get; }
        public Type Handler { get; }
        public RouteEntry(RouteTemplate template, Type handler, List<string>? unusedRouteParameterNames) 
            => (Template, UnusedRouteParameterNames, Handler) = (template, unusedRouteParameterNames, handler);           

        public void Match(RouteContext context)
        {
            var pathIndex = 0;
            var templateIndex = 0;
            Dictionary<string, object> parameters = null;

            while (pathIndex < context.Segments.Length && templateIndex < Template.Segments.Length)
            {
                var pathSegment = context.Segments[pathIndex];
                var templateSegment = Template.Segments[templateIndex];

                var matches = templateSegment.Match(pathSegment, out var match);
                if (!matches)
                {
                    // A constraint or literal didn't match
                    return;
                }

                if (!templateSegment.IsCatchAll)
                {
                    // We were dealing with a literal or a parameter, so just advance both cursors.
                    pathIndex++;
                    templateIndex++;

                    if (templateSegment.IsParameter)
                    {
                        parameters ??= new(StringComparer.OrdinalIgnoreCase);
                        parameters[templateSegment.Value] = match;
                    }
                }
                else
                {
                    if (templateSegment.Constraints.Length == 0)
                    {

                        // Unconstrained catch all, we can stop early
                        parameters ??= new(StringComparer.OrdinalIgnoreCase);
                        parameters[templateSegment.Value] = string.Join('/', context.Segments, pathIndex, context.Segments.Length - pathIndex);

                        // Mark the remaining segments as consumed.
                        pathIndex = context.Segments.Length;

                        // Catch-alls are always last.
                        templateIndex++;

                        // We are done, so break out of the loop.
                        break;
                    }
                    else
                    {
                        // For constrained catch-alls, we advance the path index but keep the template index on the catch-all.
                        pathIndex++;
                        if (pathIndex == context.Segments.Length)
                        {
                            parameters ??= new(StringComparer.OrdinalIgnoreCase);
                            parameters[templateSegment.Value] = string.Join('/', context.Segments, templateIndex, context.Segments.Length - templateIndex);

                            // This is important to signal that we consumed the entire template.
                            templateIndex++;
                        }
                    }
                }
            }

            var hasRemainingOptionalSegments = templateIndex < Template.Segments.Length &&
            RemainingSegmentsAreOptional(pathIndex, Template.Segments);

            if ((pathIndex == context.Segments.Length && templateIndex == Template.Segments.Length) || hasRemainingOptionalSegments)
            {
                if (hasRemainingOptionalSegments)
                {
                    parameters ??= new Dictionary<string, object>(StringComparer.Ordinal);
                    AddDefaultValues(parameters, templateIndex, Template.Segments);
                }
                if (UnusedRouteParameterNames?.Count > 0)
                {
                    parameters ??= new Dictionary<string, object>(StringComparer.Ordinal);
                    for (var i = 0; i < UnusedRouteParameterNames.Count; i++)
                    {
                        parameters[UnusedRouteParameterNames[i]] = null;
                    }
                }
                context.Handler = Handler;
                context.Parameters = parameters;
            }
        }

        private void AddDefaultValues(Dictionary<string, object> parameters, int templateIndex, TemplateSegment[] segments)
        {
            for (var i = templateIndex; i < segments.Length; i++)
            {
                var currentSegment = segments[i];
                parameters[currentSegment.Value] = null;
            }
        }

        private bool RemainingSegmentsAreOptional(int index, TemplateSegment[] segments)
        {
            for (var i = index; index < segments.Length - 1; index++)
            {
                if (!segments[i].IsOptional)
                {
                    return false;
                }
            }

            return segments[^1].IsOptional || segments[^1].IsCatchAll;
        } 
    }
}
