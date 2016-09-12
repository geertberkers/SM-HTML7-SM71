using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace KMTracker
{
	public partial class RitView : ContentPage
	{

		public Pin createPin(Position position, string label, string address)
		{
			return new Pin
			{
				Type = PinType.Place,
				Position = position,
				Label = label,
				Address = address
			};			
		}

		public RitView(CarView carView, Rit rit)
		{
			InitializeComponent();
			description.Text = rit.Description;

			var latitudeCount = 0.0;
			var longitudeCount = 0.0;
			var counter = 0;

			var customMap = new CustomMap
			{
				MapType = MapType.Street,
				WidthRequest = 960,
				HeightRequest = 100
			};

			foreach (Coordinate coordinate in rit.Coordinates)
			{
				latitudeCount += coordinate.Latitude;
				longitudeCount += coordinate.Longitude;
				counter++;

				var position = new Position(coordinate.Latitude, coordinate.Longitude);
				customMap.RouteCoordinates.Add(position);

				if (counter == 1)
				{
					customMap.Pins.Add(createPin(position, "Start", ""));
				}

				if (counter == rit.Coordinates.Count)
				{
					customMap.Pins.Add(createPin(position, "End", ""));
				}
			}

			var averageLatitude = latitudeCount / counter;
			var averageLongitude = longitudeCount / counter;

			customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(averageLatitude, averageLongitude), Distance.FromMiles(0.3)));
		
			stackLayout.Children.Add(customMap);
		}

	}
}

