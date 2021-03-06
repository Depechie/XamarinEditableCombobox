﻿namespace EditableCombobox.Models
{
    public class Organization
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