using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace KMTracker
{
	public partial class RitView : ContentPage
	{
		
		public RitView(CarView carView, Rit rit)
		{
			InitializeComponent();
			description.Text = rit.Description;

			var latitudeCount = 0.0;
			var longitudeCount = 0.0;
			var counter = 0;

			foreach (Coordinate coordinate in rit.Coordinates)
			{
				latitudeCount += coordinate.Latitude;
				longitudeCount += coordinate.Longitude;
				counter++;
			}

			var averageLatitude = latitudeCount / counter;
			var averageLongitude = longitudeCount / counter;

			var map = new Map(MapSpan.FromCenterAndRadius(new Position(averageLatitude, averageLongitude), Distance.FromMiles(0.3)))
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			foreach (Coordinate coordinate in rit.Coordinates)
			{
				//TODO: Remove points, add line
				var position = new Position(coordinate.Latitude, coordinate.Longitude); // Latitude, Longitude
				var pin = new Pin
				{
					Type = PinType.Place,
					Position = position,
					Label = "Point " + rit.Coordinates.FindIndex((obj) => obj == coordinate),//.Latitude == coordinate.Latitude),
					Address = "custom detail info"
				};
				map.Pins.Add(pin);
			}

			stackLayout.Children.Add(map);
		}

	}
}

