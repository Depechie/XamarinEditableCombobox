using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using EditableCombobox.Models.Interfaces;
using Xamarin.Forms;

namespace EditableCombobox.Controls
{
    public partial class EditableCombobox : ContentView
    {
        private ListFilter _listFilter = new ListFilter();

        #region Bindable properties
        public static readonly BindableProperty ImageNameProperty = BindableProperty.Create(nameof(ImageName), typeof(string), typeof(EditableCombobox), string.Empty, propertyChanged:OnImageNamePropertyChanged);
        public static readonly BindableProperty CaptionProperty = BindableProperty.Create(nameof(Caption), typeof(string), typeof(EditableCombobox), string.Empty, propertyChanged:OnCaptionPropertyChanged);
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<IKeyValue>), typeof(EditableCombobox), null, propertyChanged: OnItemsSourcePropertyChanged);

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

        public IEnumerable<IKeyValue> ItemsSource
        {
            get => (IEnumerable<IKeyValue>)GetValue(ItemsSourceProperty);
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
            ((EditableCombobox)bindable).ItemsSourceChanged(oldValue, newValue);
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

        private void ItemsSourceChanged(object oldValue, object newValue)
        {
            var oldValueINotifyCollectionChanged = oldValue as INotifyCollectionChanged;

            if (oldValueINotifyCollectionChanged != null)
                oldValueINotifyCollectionChanged.CollectionChanged -= OnCollectionChanged;

            var newValueINotifyCollectionChanged = newValue as INotifyCollectionChanged;

            if (newValueINotifyCollectionChanged != null)
                newValueINotifyCollectionChanged.CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (IKeyValue item in e.OldItems)
                    _listFilter.Collection.Remove(item);
            }


            if (e.NewItems != null)
            {
                foreach (IKeyValue item in e.NewItems)
                    _listFilter.Collection.Add(item);
            }
        }

        private async void OnTapped(object sender, System.EventArgs e)
        {
            ContentPage popup = new ContentPage();

            if (ItemsSource != null)
            {
                popup.Content = _listFilter;
                popup.Appearing += OnAppearing;

                await Navigation.PushModalAsync(popup);
            }
        }

        private void OnAppearing(object sender, EventArgs e)
        {
            _listFilter.Appearing();
        }
    }
}