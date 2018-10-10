using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace EditableCombobox
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private string _imageName;
        public string ImageName
        {
            get => _imageName;
            set
            {
                _imageName = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            EditCB.BindingContext = this;
            ImageName = "iconlocation.png";
        }

        private void HandleTapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new ListSelectionPage());
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            ImageName = "iconorganization.png";
        }
    }
}
