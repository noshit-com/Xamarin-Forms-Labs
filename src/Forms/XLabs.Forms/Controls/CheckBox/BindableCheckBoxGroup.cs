using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace XLabs.Forms.Controls
{
	/// <summary>
	/// Bindable check box group.
	/// </summary>
	public class BindableCheckBoxGroup : StackLayout
	{
		/// <summary>
		/// The items.
		/// </summary>
		public ObservableCollection<CheckBox> Items;

		/// <summary>
		/// Initializes a new instance of the <see cref="XLabs.Forms.Controls.BindableCheckBoxGroup"/> class.
		/// </summary>
		public BindableCheckBoxGroup ()
		{
			Items = new ObservableCollection<CheckBox> ();
		}

		/// <summary>
		/// The items source property.
		/// </summary>
		public static BindableProperty ItemsSourceProperty =
			BindableProperty.Create<BindableCheckBoxGroup, IEnumerable> (o => o.ItemsSource, default(IEnumerable));
		//, propertyChanged: OnItemsSourceChanged);

		/// <summary>
		/// The text color property.
		/// </summary>
		public static readonly BindableProperty TextColorProperty =
			BindableProperty.Create<BindableCheckBoxGroup, Color>(
				p => p.TextColor, Color.Default);

		/// <summary>
		/// The font size property
		/// </summary>
		public static readonly BindableProperty FontSizeProperty =
			BindableProperty.Create<BindableCheckBoxGroup, double>(
				p => p.FontSize, -1);

		/// <summary>
		/// The font name property.
		/// </summary>
		public static readonly BindableProperty FontNameProperty =
			BindableProperty.Create<BindableCheckBoxGroup, string>(
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

				foreach (CheckBox item in originalValue)
				{
					var checkBox = new CheckBox
					{
						ClassId = item.ClassId, Checked = item.Checked, CheckedText = item.CheckedText,
						FontName = FontName, FontSize = Device.GetNamedSize(NamedSize.Small, this),
						HeightRequest = item.HeightRequest, HorizontalOptions = item.HorizontalOptions,
						IsEnabled = item.IsEnabled, IsVisible = item.IsVisible,
						Style = item.Style, StyleId = item.StyleId, DefaultText = item.DefaultText, 
						TextColor = item.TextColor, UncheckedText = item.UncheckedText, 
						VerticalOptions = item.VerticalOptions, WidthRequest = item.WidthRequest
					};

					//checkBox.CheckedChanged += OnCheckedChanged;

					Items.Add(checkBox);

					Children.Add(checkBox);
				}

				SetValue (ItemsSourceProperty, Items);
			}
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
	}
}

