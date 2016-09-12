using System.Collections.Generic;
using System.Threading.Tasks;
using PCLStorage;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace KMTracker
{
	public partial class CarView : ContentPage
	{
		Car selectedCar;
		CarMenu carMenu;

		bool isTracking = false;
		List<Coordinate> coordinates;

		public CarView(CarMenu menu, Car car)
		{
			InitializeComponent();
			coordinates = new List<Coordinate>();

			carMenu = menu;
			selectedCar = car;

			Car.Text = car.Name;
			NumberPlate.Text = car.NumberPlate;
			Mileage.Text = car.MileAge.ToString("F1");

			var dataTemplate = new DataTemplate(typeof(TextCell));
			dataTemplate.SetBinding(TextCell.TextProperty, "Description");

			Rittenlijst.ItemsSource = selectedCar.Ritten;
			Rittenlijst.ItemTemplate = dataTemplate;
			Rittenlijst.ItemTapped += (s, e) => selectRit((Rit)e.Item);
			Rittenlijst.ItemSelected += (s, e) =>
			{
				Rittenlijst.SelectedItem = null;
			};
			gpsButton.Clicked += (s, e) => StartOrStopTracking();
		}

		void selectRit(Rit rit)
		{
			var ritView = new RitView(this, rit);
			Navigation.PushModalAsync(ritView);
		}

		void StartOrStopTracking()
		{
			isTracking = !isTracking;

			trackingLabel.Text = "Currently tracking: " + isTracking.ToString();

			// Start tracking
			if (isTracking)
			{
				gpsButton.Text = "Tracking GPS";
				StartTracking();
			}
			else {
				gpsButton.Text = "Track GPS";
				locationLabel.Text = "No GPS location found yet";

				StopTracking();
			}
		}

		async void StartTracking()
		{
			await TrackGPS();
		}

		async void StopTracking()
		{
			await SaveTrackedGPSToInternalStorage();
		}

		async Task TrackGPS()
		{
			gpsButton.Text = "Tracking GPS";

			if (isTracking)
			{
				var locator = CrossGeolocator.Current;
				locator.AllowsBackgroundUpdates = true;
				locator.DesiredAccuracy = 10;

				var position = await locator.GetPositionAsync(timeoutMilliseconds: 60000);

				System.Diagnostics.Debug.WriteLine("Position Status: {0}", position.Timestamp);
				System.Diagnostics.Debug.WriteLine("Position Latitude: {0}", position.Latitude);
				System.Diagnostics.Debug.WriteLine("Position Longitude: {0}", position.Longitude);

				coordinates.Add(new Coordinate(position.Longitude, position.Latitude));

				locationLabel.Text = "Current GPS location: " + position.Latitude + " / " + position.Longitude;

				if (isTracking)
				{
					//TODO: Wait a few seconds before tracking again, else a lot of data
					await TrackGPS();
				}
			}
		}

		public async Task SaveTrackedGPSToInternalStorage()
		{
			var FileText = "";
			foreach (Coordinate coordinate in coordinates)
			{
				FileText += "coordinates.Add(new Coordinate(" + coordinate.Latitude + ", " + coordinate.Longitude + "));\n";
			}

			IFolder rootFolder = FileSystem.Current.LocalStorage;
			IFolder folder = await rootFolder.CreateFolderAsync("Coordinates", CreationCollisionOption.OpenIfExists);
			IFile file = await folder.CreateFileAsync("Rit" + selectedCar.Ritten.Count + ".txt", CreationCollisionOption.ReplaceExisting);
			await file.WriteAllTextAsync(FileText);
	
		}

		protected override bool OnBackButtonPressed()
		{
			//TODO: Check if you actually traveled, else dont add it.

			if (coordinates.Count >= 3)
			{
				var description = "TestRit";
				selectedCar.Ritten.Add(new Rit(description, coordinates));
			}

			Application.Current.MainPage = carMenu;

			return true;
			// return base.OnBackButtonPressed() kills application
		}
	}
}

