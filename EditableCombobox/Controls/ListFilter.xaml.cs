using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using EditableCombobox.Models.Interfaces;
using Xamarin.Forms;

namespace EditableCombobox.Controls
{
    public partial class ListFilter : ContentView, INotifyPropertyChanged
    {
        public event EventHandler ItemSelected;

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
                _selectedItem = value;
                OnPropertyChanged();

                if (!(_selectedItem is null))
                    OnItemSelected(null);
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
    }
}