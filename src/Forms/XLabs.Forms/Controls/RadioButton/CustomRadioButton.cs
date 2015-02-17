using System;
using Xamarin.Forms;

namespace XLabs.Forms.Controls
{
    public class CustomRadioButton : View
    {
		/// <summary>
		/// The default checked property.
		/// </summary>
        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create<CustomRadioButton, bool>(
                p => p.Checked, false);

        /// <summary>
        ///     The default text property.
        /// </summary>
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create<CustomRadioButton, string>(
                p => p.Text, string.Empty);

        /// <summary>
        ///     The default text property.
        /// </summary>
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create<CustomRadioButton, Color>(
                p => p.TextColor, Color.Default);

        /// <summary>
        /// The font size property
        /// </summary>
        public static readonly BindableProperty FontSizeProperty =
			BindableProperty.Create<CustomRadioButton, double>(
                p => p.FontSize, -1);

        /// <summary>
        /// The font name property.
        /// </summary>
        public static readonly BindableProperty FontNameProperty =
			BindableProperty.Create<CustomRadioButton, string>(
                p => p.FontName, string.Empty);

        /// <summary>
        ///     The checked changed event.
        /// </summary>
        public EventHandler<EventArgs<bool>> CheckedChanged;

        /// <summary>
        ///     Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        public bool Checked
        {
            get { return this.GetValue<bool>(CheckedProperty); }

            set
            {
                SetValue(CheckedProperty, value);

                var eventHandler = CheckedChanged;

                if (eventHandler != null)
                {
                    eventHandler.Invoke(this, value);
                }
            }
        }

		/// <summary>
		/// Gets or sets the control text value.
		/// </summary>
		/// <value>The text.</value>
        public string Text
        {
            get { return this.GetValue<string>(TextProperty); }

            set { SetValue(TextProperty, value); }
        }

		/// <summary>
		/// Gets or sets the control text color value.
		/// </summary>
		/// <value>The color of the text.</value>
        public Color TextColor
        {
            get { return this.GetValue<Color>(TextColorProperty); }

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
		/// Gets a value that can be used to uniquely identify the control element.
		/// </summary>
		/// <value>An int uniquely identifying the element.</value>
        public int Id { get; set; }
    }
}