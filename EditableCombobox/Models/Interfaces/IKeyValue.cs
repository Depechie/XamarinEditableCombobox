using System;

namespace EditableCombobox.Models.Interfaces
{
    public interface IKeyValue
    {
        object Key { get; set; }
        string Value { get; }
    }
}