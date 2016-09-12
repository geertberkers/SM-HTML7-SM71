using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace KMTracker
{
	public partial class CarView : ContentPage
	{
		Car selectedCar;
		CarMenu carMenu;

		List<Coordinate> coordinates;

		public CarView(CarMenu menu, Car car)
		{
			InitializeComponent();
			coordinates = new List<Coordinate>();

			carMenu = menu;
			selectedCar = car;

			// Testdata
			coordinates.Add(new Coordinate(11, 4));
			coordinates.Add(new Coordinate(12, 5));
			coordinates.Add(new Coordinate(13, 6));
			selectedCar.Ritten.Add(new Rit("Test", coordinates));
			selectedCar.Ritten.Add(new Rit("Nieuwe Rit", coordinates));

			Car.Text = car.Name;
			NumberPlate.Text = car.NumberPlate;
			Mileage.Text = car.MileAge.ToString();

			var dataTemplate = new DataTemplate(typeof(TextCell));
			dataTemplate.SetBinding(TextCell.TextProperty, "Description");

			Rittenlijst.ItemsSource = selectedCar.Ritten;
			Rittenlijst.ItemTemplate = dataTemplate;
			Rittenlijst.ItemTapped += (s, e) => selectRit((Rit)e.Item);

			gpsButton.Clicked += (s, e) => OnGPS();
		}

		void selectRit(Rit rit)
		{
			var ritView = new RitView(this, rit);
			Navigation.PushModalAsync(ritView);
			//Application.Current.MainPage = new RitView(this, rit)
		}

		async void OnGPS()
		{
			var locator = CrossGeolocator.Current;
			locator.AllowsBackgroundUpdates = true;
			locator.DesiredAccuracy = 10;

			var position = await locator.GetPositionAsync(timeoutMilliseconds: 60000);

			System.Diagnostics.Debug.WriteLine("Position Status: {0}", position.Timestamp);
			System.Diagnostics.Debug.WriteLine("Position Latitude: {0}", position.Latitude);
			System.Diagnostics.Debug.WriteLine("Position Longitude: {0}", position.Longitude);

			coordinates.Add(new Coordinate(position.Longitude, position.Latitude));

			locationLabel.Text = "GPS: " + position.Latitude + " / " + position.Longitude;
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

