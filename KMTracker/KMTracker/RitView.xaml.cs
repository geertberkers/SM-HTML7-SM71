using System;
using System.Collections.Generic;

using Xamarin.Forms;

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
		}
	}
}

