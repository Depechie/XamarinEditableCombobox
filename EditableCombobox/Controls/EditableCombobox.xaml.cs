using System;
using System.Collections;
using Xamarin.Forms;

namespace EditableCombobox.Controls
{
    public partial class EditableCombobox : ContentView
    {
        private ListFilter _listFilter = new ListFilter();

        #region Bindable properties
        public static readonly BindableProperty ImageNameProperty = BindableProperty.Create(nameof(ImageName), typeof(string), typeof(EditableCombobox), string.Empty, propertyChanged:OnImageNamePropertyChanged);
        public static readonly BindableProperty CaptionProperty = BindableProperty.Create(nameof(Caption), typeof(string), typeof(EditableCombobox), string.Empty, propertyChanged:OnCaptionPropertyChanged);
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(EditableCombobox), null, propertyChanged: OnItemsSourcePropertyChanged);

        public string ImageName
        {
            get => (string)GetValue(ImageNameProperty);
            set => SetValue(ImageNameProperty, value);
        }

        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private static void OnImageNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((EditableCombobox)bindable).InitIcon();
        }

        private static void OnCaptionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((EditableCombobox)bindable).InitCaption();
        }

        private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((EditableCombobox)bindable).InitItemsSource();
        }
        #endregion

        public EditableCombobox()
        {
            InitializeComponent();
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            InitIcon();
            InitCaption();
            InitItemsSource();
        }

        private void InitIcon()
        {
            Icon.Source = ImageName;
        }

        private void InitCaption()
        {
            Content.Text = Caption;
        }

        private void InitItemsSource()
        {}

        private async void OnTapped(object sender, System.EventArgs e)
        {
            ContentPage popup = new ContentPage();
            popup.Content = _listFilter;
            popup.Appearing += OnAppearing;

            await Navigation.PushModalAsync(popup);
        }

        private void OnAppearing(object sender, EventArgs e)
        {
            _listFilter.Appearing();
        }
    }
}