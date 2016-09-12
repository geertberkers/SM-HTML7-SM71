using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace KMTracker
{
	public partial class RitView : ContentPage
	{
		CarView carView;
		Rit rit;

		public RitView(CarView carView, Rit rit)
		{
			InitializeComponent();

			this.rit = rit;
			this.carView = carView;

			var map = new Map(
			MapSpan.FromCenterAndRadius(
					new Position(37, -122), Distance.FromMiles(0.3)))
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			//var stack = new StackLayout { Spacing = 0 };
			//stack.Children.Add(map);
			//Content = stack;

			stackLayout.Children.Add(map);
		}

	}
}

