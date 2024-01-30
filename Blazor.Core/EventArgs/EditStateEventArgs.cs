namespace Blazor.Core
{
    public class EditStateEventArgs : EventArgs
    {
        public bool IsDirty { get; set; }

        public static EditStateEventArgs NewArgs(bool dirtyState)
            => new EditStateEventArgs { IsDirty = dirtyState };
    }
}
