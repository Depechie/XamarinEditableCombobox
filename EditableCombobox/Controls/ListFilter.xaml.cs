using System.Collections.ObjectModel;
using System.ComponentModel;
using EditableCombobox.Models.Interfaces;
using Xamarin.Forms;

namespace EditableCombobox.Controls
{
    public partial class ListFilter : ContentView, INotifyPropertyChanged
    {
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

        public ListFilter()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public void Appearing()
        {
            SelectionFilter.Focus();
        }
    }
}