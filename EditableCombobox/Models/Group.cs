namespace EditableCombobox.Models
{
    public class Group
    {
        public object Key { get; set; }
        public string Name { get; set; }

        public string Value { get => Name; }

        public override string ToString()
        {
            return Value;
        }
    }
}