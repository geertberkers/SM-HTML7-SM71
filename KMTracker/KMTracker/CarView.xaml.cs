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

		DataTemplate dataTemplate;

		public CarView(CarMenu menu, Car car)
		{
			InitializeComponent();
			coordinates = new List<Coordinate>();

			carMenu = menu;
			selectedCar = car;

			Car.Text = car.Name;
			NumberPlate.Text = car.NumberPlate;
			Mileage.Text = car.MileAge.ToString("F1");

			dataTemplate = new DataTemplate(typeof(TextCell));
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

			trackingLabel.Text = "Currently tracking: " + isTracking;

			// Start tracking
			if (isTracking)
			{
				gpsButton.Text = "Stop rit!";
				StartTracking();
			}
			else {
				gpsButton.Text = "Start rit!";
				locationLabel.Text = "No GPS location found yet";

				//TODO: Check if you actually traveled, else dont add it.
				if (coordinates.Count >= 5)
				{
					var description = "TestRit";
					selectedCar.Ritten.Add(new Rit(description, coordinates));
					Rittenlijst.ItemsSource = selectedCar.Ritten;
					Rittenlijst.ItemTemplate = dataTemplate;

					StopTracking();
				}
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

				// New if statement, because tracking can be stopped before it reaches this code
				if (isTracking)
				{
					System.Diagnostics.Debug.WriteLine("Position Status: {0}", position.Timestamp);
					System.Diagnostics.Debug.WriteLine("Position Latitude: {0}", position.Latitude);
					System.Diagnostics.Debug.WriteLine("Position Longitude: {0}", position.Longitude);

					coordinates.Add(new Coordinate(position.Latitude, position.Longitude));

					locationLabel.Text = "Current GPS location: " + position.Latitude + " / " + position.Longitude;

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
			Application.Current.MainPage = carMenu;

			return true;
			// return base.OnBackButtonPressed() kills application
		}
	}
}

