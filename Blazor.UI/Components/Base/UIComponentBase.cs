using Microsoft.AspNetCore.Components;

namespace Blazor.UI
{
    public class UIComponentBase : ComponentBase
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> UserAttributes { get; set; } = new Dictionary<string, object>();

        protected virtual List<string> UnwantedAttributes { get; set; } = new List<string>();

        protected Dictionary<string, object> SplatterAttributes
        {
            get
            {
                var list = new Dictionary<string, object>();
                foreach (var item in UserAttributes)
                {
                    if (!UnwantedAttributes.Any(item1 => item1.Equals(item.Key)))
                        list.Add(item.Key, item.Value);
                }
                return list;
            }
        }
    }
}
