using System;
using Xamarin.Forms;

namespace EditableCombobox.Controls
{
    public partial class EditableCombobox : ContentView
    {
        private ListFilter _listFilter = new ListFilter();

        #region Bindable properties
        public static readonly BindableProperty ImageNameProperty = BindableProperty.Create(nameof(ImageName), typeof(string), typeof(EditableCombobox), string.Empty, propertyChanged:OnImageNamePropertyChanged);
        public static readonly BindableProperty CaptionProperty = BindableProperty.Create(nameof(Caption), typeof(string), typeof(EditableCombobox), string.Empty, propertyChanged:OnCaptionPropertyChanged);

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

        private static void OnImageNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((EditableCombobox)bindable).InitIcon();
        }

        private static void OnCaptionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((EditableCombobox)bindable).InitCaption();
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
        }

        private void InitIcon()
        {
            Icon.Source = ImageName;
        }

        private void InitCaption()
        {
            Content.Text = Caption;
        }

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