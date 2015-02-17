using CoreGraphics;
using Foundation;
using UIKit;

namespace XLabs.Forms.Controls
{
    [Register("RadioButtonView")]
	/// <summary>
	/// Radio button view.
	/// </summary>
    public class RadioButtonView : UIButton
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="XLabs.Forms.Controls.RadioButtonView"/> class.
		/// </summary>
        public RadioButtonView()
        {
            Initialize();
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="XLabs.Forms.Controls.RadioButtonView"/> class.
		/// </summary>
		/// <param name="bounds">Bounds.</param>
        public RadioButtonView(CGRect bounds)
            : base(bounds)
        {
            Initialize();
        }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="XLabs.Forms.Controls.RadioButtonView"/> is checked.
		/// </summary>
		/// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            set { this.Selected = value; }
            get { return this.Selected; }
        }

		/// <summary>
		/// Sets the text.
		/// </summary>
		/// <value>The text.</value>
        public string Text
        {
            set { this.SetTitle(value, UIControlState.Normal); }
            
        }

        void Initialize()
        {
            this.AdjustEdgeInsets();
            this.ApplyStyle();

			this.TouchUpInside += RadioButtonClicked;
		}

        void AdjustEdgeInsets()
        {
            const float inset = 8f;

            this.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            this.ImageEdgeInsets = new UIEdgeInsets(0f, inset, 0f, 0f);
            this.TitleEdgeInsets = new UIEdgeInsets(0f, inset * 2, 0f, 0f);
        }

        void ApplyStyle()
        {
            this.SetImage(UIImage.FromBundle("Images/RadioButton/checked.png"), UIControlState.Selected);
            this.SetImage(UIImage.FromBundle("Images/RadioButton/unchecked.png"), UIControlState.Normal);
		}

		void RadioButtonClicked (object sender, System.EventArgs args)
		{
			this.Selected = !this.Selected;
		}

		/// <summary>
		/// Removes the click event.
		/// </summary>
		public void RemoveClickEvent()
		{
			this.TouchUpInside -= RadioButtonClicked;
		}
    }
}