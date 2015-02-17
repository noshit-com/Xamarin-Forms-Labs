using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace XLabs.Forms.Controls
{
	/// <summary>
	/// Bindable radio group.
	/// </summary>
    public class BindableRadioGroup : StackLayout
    {
		/// <summary>
		/// The items.
		/// </summary>
        public ObservableCollection<CustomRadioButton> Items;

		/// <summary>
		/// Initializes a new instance of the <see cref="XLabs.Forms.Controls.BindableRadioGroup"/> class.
		/// </summary>
        public BindableRadioGroup()
        {
            Items = new ObservableCollection<CustomRadioButton> ();
        }

		/// <summary>
		/// The items source property.
		/// </summary>
        public static BindableProperty ItemsSourceProperty =
			BindableProperty.Create<BindableRadioGroup, IEnumerable> (o => o.ItemsSource, default(IEnumerable));
				//, propertyChanged: OnItemsSourceChanged);

		/// <summary>
		/// The selected index property.
		/// </summary>
        public static BindableProperty SelectedIndexProperty =
            BindableProperty.Create<BindableRadioGroup, int>(o => o.SelectedIndex, default(int), BindingMode.TwoWay,
                propertyChanged: OnSelectedIndexChanged);

		/// <summary>
		/// The text color property.
		/// </summary>
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create<CheckBox, Color>(
                p => p.TextColor, Color.Default);

        /// <summary>
        /// The font size property
        /// </summary>
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create<CheckBox, double>(
                p => p.FontSize, -1);

        /// <summary>
        /// The font name property.
        /// </summary>
        public static readonly BindableProperty FontNameProperty =
            BindableProperty.Create<CheckBox, string>(
                p => p.FontName, string.Empty);

		/// <summary>
		/// Gets or sets the items source.
		/// </summary>
		/// <value>The items source.</value>
		public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set
            {
				IEnumerable originalValue = value;

                Items.Clear();
                Children.Clear();

                int radIndex = 0;

				foreach (CustomRadioButton item in originalValue)
                {
                    var button = new CustomRadioButton
                    {
						ClassId = item.ClassId, Checked = item.Checked,
						FontName = FontName, FontSize = Device.GetNamedSize(NamedSize.Small, this),
						HeightRequest = item.HeightRequest, HorizontalOptions = item.HorizontalOptions,
						Id = radIndex++, IsEnabled = item.IsEnabled, IsVisible = item.IsVisible,
						Style = item.Style, StyleId = item.StyleId, Text = item.Text, TextColor = TextColor,
						VerticalOptions = item.VerticalOptions, WidthRequest = item.WidthRequest
                    };

                    button.CheckedChanged += OnCheckedChanged;

                    Items.Add(button);

                    Children.Add(button);
                }

				SetValue (ItemsSourceProperty, Items);
            }
		}
		/*public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}*/

		/// <summary>
		/// Raises the items source changed event.
		/// </summary>
		/// <param name="bindable">Bindable.</param>
		/// <param name="oldvalue">Oldvalue.</param>
		/// <param name="newvalue">Newvalue.</param>
		/*private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
		{
			BindableRadioGroup radButtons = (BindableRadioGroup)bindable;

			radButtons.Items.Clear();
			radButtons.Children.Clear();
			if (newvalue != null) {
				int radIndex = 0;
				ObservableCollection<CustomRadioButton> tmpRads = new ObservableCollection<CustomRadioButton> ();
				foreach (CustomRadioButton item in newvalue) {
					CustomRadioButton rad = new CustomRadioButton {
						Checked = item.Checked, ClassId = item.ClassId,
						//FontName = FontName, FontSize = Device.GetNamedSize (NamedSize.Small, bindable),
						HeightRequest = item.HeightRequest, Id = radIndex++, Style = item.Style,
						StyleId = item.StyleId, Text = item.Text, TextColor = item.TextColor,
					};
					rad.CheckedChanged += radButtons.OnCheckedChanged;

					radButtons.Items.Add(rad);

					radButtons.Children.Add(rad);
				}
			}
		}*/

		/// <summary>
		/// Gets or sets the index of the selected.
		/// </summary>
		/// <value>The index of the selected.</value>
        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

		/// <summary>
		/// Gets or sets the color of the text.
		/// </summary>
		/// <value>The color of the text.</value>
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        /// <value>The size of the font.</value>
        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the name of the font.
        /// </summary>
        /// <value>The name of the font.</value>
        public string FontName
        {
            get
            {
                return (string)GetValue(FontNameProperty);
            }
            set
            {
                SetValue(FontNameProperty, value);
            }
        }

		/// <summary>
		/// Occurs when checked changed.
		/// </summary>
        public event EventHandler<int> CheckedChanged;

		/// <summary>
		/// Raises the checked changed event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void OnCheckedChanged(object sender, EventArgs<bool> e)
        {
            if (e.Value == false)
            {
                return;
            }

            var selectedItem = sender as CustomRadioButton;

            if (selectedItem == null)
            {
                return;
            }

            foreach (var item in Items)
            {
                if (!selectedItem.Id.Equals(item.Id))
                {
                    item.Checked = false;
                }
                else
                {
                    if (CheckedChanged != null)
                    {
                        CheckedChanged.Invoke(sender, item.Id);
                    }
                }
            }
        }

		/// <summary>
		/// Raises the selected index changed event.
		/// </summary>
		/// <param name="bindable">Bindable.</param>
		/// <param name="oldvalue">Oldvalue.</param>
		/// <param name="newvalue">Newvalue.</param>
        private static void OnSelectedIndexChanged(BindableObject bindable, int oldvalue, int newvalue)
        {
            if (newvalue == -1)
            {
                return;
            }

            var bindableRadioGroup = bindable as BindableRadioGroup;

            if (bindableRadioGroup == null)
            {
                return;
            }

            foreach (var button in bindableRadioGroup.Items.Where(button => button.Id == bindableRadioGroup.SelectedIndex))
            {
                button.Checked = true;
            }
        }
    }
}
