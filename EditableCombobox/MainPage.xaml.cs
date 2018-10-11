using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EditableCombobox.Models;
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

        private ObservableCollection<Organization> _organizations = new ObservableCollection<Organization>();
        public ObservableCollection<Organization> Organizations
        {
            get => _organizations;
            set
            {
                _organizations = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            EditCB.BindingContext = this;
            ImageName = "iconlocation.png";

            Organizations.Add(new Organization() { Name = "Org Abc" });
            Organizations.Add(new Organization() { Name = "Org Def" });
            Organizations.Add(new Organization() { Name = "Org Ghi" });
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
