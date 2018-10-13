using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using EditableCombobox.Models.Interfaces;
using Xamarin.Forms;

namespace EditableCombobox.Controls
{
    public partial class ListFilter : ContentView, INotifyPropertyChanged
    {
        public event EventHandler ItemSelected;

        public IEnumerable<IKeyValue> UnFilteredCollection { get; set; }

        private ObservableCollection<IKeyValue> _collection = new ObservableCollection<IKeyValue>();
        public ObservableCollection<IKeyValue> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                OnPropertyChanged();
            }
        }

        private IKeyValue _selectedItem;
        public IKeyValue SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    OnPropertyChanged();

                    if (!(_selectedItem is null))
                        OnItemSelected(null);
                }
            }
        }

        public ListFilter()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public void Appearing()
        {
            SelectionFilter.Focus();
        }

        protected virtual void OnItemSelected(EventArgs e)
        {
            ItemSelected?.Invoke(this, e);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SelectionFilter.Text))
                Collection = new ObservableCollection<IKeyValue>(UnFilteredCollection);
            else
                Collection = new ObservableCollection<IKeyValue>(UnFilteredCollection.Where(i => i.Value.StartsWith(SelectionFilter.Text, StringComparison.OrdinalIgnoreCase)));
        }
    }
}