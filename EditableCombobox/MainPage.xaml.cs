using System.Collections.ObjectModel;
using System.ComponentModel;
using EditableCombobox.Models;
using Xamarin.Forms;

namespace EditableCombobox
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
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

        private Organization _selectedOrganization;
        public Organization SelectedOrganization
        {
            get => _selectedOrganization;
            set
            {
                _selectedOrganization = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Location> _locations = new ObservableCollection<Location>();
        public ObservableCollection<Location> Locations
        {
            get => _locations;
            set
            {
                _locations = value;
                OnPropertyChanged();
            }
        }

        private Location _selectedLocation;
        public Location SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                _selectedLocation = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Group> _groups = new ObservableCollection<Group>();
        public ObservableCollection<Group> Groups
        {
            get => _groups;
            set
            {
                _groups = value;
                OnPropertyChanged();
            }
        }

        private Group _selectedGroup;
        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;

            Organizations.Add(new Organization() { Name = "Abc" });
            Organizations.Add(new Organization() { Name = "Def" });
            Organizations.Add(new Organization() { Name = "Ghi" });

            Locations.Add(new Location() { Name = "Abc" });
            Locations.Add(new Location() { Name = "Def" });
            Locations.Add(new Location() { Name = "Ghi" });

            Groups.Add(new Group() { Name = "Abc" });
            Groups.Add(new Group() { Name = "Def" });
            Groups.Add(new Group() { Name = "Ghi" });
        }
    }
}
