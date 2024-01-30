namespace Blazor.Core
{
    public class EditField
    {
        public string? FieldName { get; set; }
        public Guid Guid { get; init; }
        public object Value { get; init; }

        public object EditedValue { get; set; }

        public object Model { get; init; }

        public bool IsDirty
        {
            get
            {
                if(Value is not null && EditedValue is not null)
                   return !Value.Equals(EditedValue);
                if (Value is null && EditedValue is null)
                    return false;
                return true;
            }
        }

        public EditField(object model, string fieldName, object value) =>
            (Model, FieldName, Value, EditedValue, Guid) = (model, fieldName, value, value, Guid.NewGuid());

        public void Reset() => EditedValue = Value;
    }
}
