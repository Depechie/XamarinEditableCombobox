using Xamarin.Forms;

namespace EditableCombobox.Controls
{
    public partial class ListFilter : ContentView
    {
        public ListFilter()
        {
            InitializeComponent();
        }

        public void Appearing()
        {
            SelectionEntry.Focus();
        }
    }
}