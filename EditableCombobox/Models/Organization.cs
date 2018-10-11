﻿using System;
using EditableCombobox.Models.Interfaces;

namespace EditableCombobox.Models
{
    public class Organization : IKeyValue
    {
        public object Key { get; set; }
        public string Name { get; set; }

        public string Value { get => Name; }
    }
}