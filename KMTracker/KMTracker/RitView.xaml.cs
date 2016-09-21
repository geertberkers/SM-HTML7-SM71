using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace KMTracker
{
	public partial class RitView : ContentPage
	{

		Geocoder geocoder;
		string address;

		Pin endPin;
		Pin startPin;

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

		public async Task<string> GetAdressFromPosition(Position position)
		{
			var possibleAddresses = await geocoder.GetAddressesForPositionAsync(position);

			var first = true;
			foreach (var a in possibleAddresses)
			{
				if (first)
				{
					first = !first;
					address = a.Replace("\n", " ");
				}
			}

			return address;
		}

		public RitView(CarView carView, Rit rit)
		{
			InitializeComponent();
			description.Text = rit.Description;

			this.Title = rit.Description;

			geocoder = new Geocoder();
			var latitudeCount = 0.0;
			var longitudeCount = 0.0;
			var counter = 0;

			// Dont try to draw a map if there are no coordinates
			if (rit.Coordinates.Count == 0)
			{
				return;
			}
			
			foreach (Coordinate coordinate in rit.Coordinates)
			{
				counter++;
				var position = new Position(coordinate.Latitude, coordinate.Longitude);
				if (counter == 1)
				{
					customMap.Pins.Add(createPin(position, "Start", ""));
					GetAddressAddPoint(position, "Start");
				}

				if (counter == rit.Coordinates.Count)
				{
					customMap.Pins.Add(createPin(position, "End", ""));

					GetAddressAddPoint(position, "Eind");
				}

				latitudeCount += coordinate.Latitude;
				longitudeCount += coordinate.Longitude;

				customMap.RouteCoordinates.Add(position);
			}

			var averageLatitude = latitudeCount / counter;
			var averageLongitude = longitudeCount / counter;

			customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(averageLatitude, averageLongitude), Distance.FromMiles(0.3)));
		}

		async void GetAddressAddPoint(Position position, string beginOrEnd)
		{
			await GetAdressFromPosition(position);

			if (beginOrEnd == "Start")
			{
				startPin = createPin(position, beginOrEnd, address);
			}
			else if (beginOrEnd == "Eind")
			{
				endPin = createPin(position, beginOrEnd, address);
			}

			if (startPin != null && endPin != null)
			{
				customMap.Pins.Clear();
				customMap.Pins.Add(startPin);
				customMap.Pins.Add(endPin);
			}
		}

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
			customMap.HeightRequest = height;
			customMap.WidthRequest = width;
		}
	}
}

