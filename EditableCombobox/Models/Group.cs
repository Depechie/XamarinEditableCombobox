using EditableCombobox.Models.Interfaces;

namespace EditableCombobox.Models
{
    public class Group : IKeyValue
    {
        public object Key { get; set; }
        public string Name { get; set; }

        public string Value { get => Name; }
    }
}