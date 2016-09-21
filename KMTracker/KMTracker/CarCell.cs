using System;
using Xamarin.Forms;

namespace KMTracker
{
	public class CarCell : ViewCell
	{
		public CarCell()
		{
			var carText = new Label();
			carText.SetBinding(Label.TextProperty, "Name");
			carText.HorizontalOptions = LayoutOptions.Center;
			//carText.FontSize = 20;

			var numberPlateText = new Label();
			//numberPlateText.FontSize = 20;
			numberPlateText.SetBinding(Label.TextProperty, "NumberPlate");
			numberPlateText.HorizontalOptions = LayoutOptions.Center;

			var view = new StackLayout()
			{
				Children = {
					carText,
					numberPlateText
				}
			};

			View = view;
		}
	}
}

