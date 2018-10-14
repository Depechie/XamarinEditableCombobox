using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace EditableCombobox.Controls
{
    public partial class ListFilter : ContentView, INotifyPropertyChanged
    {
        public event EventHandler ItemSelected;

        public IEnumerable<object> UnFilteredCollection { get; set; }

        private ObservableCollection<object> _collection = new ObservableCollection<object>();
        public ObservableCollection<object> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                OnPropertyChanged();
            }
        }

        private object _selectedItem;
        public object SelectedItem
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
                Collection = new ObservableCollection<object>(UnFilteredCollection);
            else
                Collection = new ObservableCollection<object>(UnFilteredCollection.Where(i => i.ToString().IndexOf(SelectionFilter.Text, StringComparison.OrdinalIgnoreCase) != -1));
        }
    }
}