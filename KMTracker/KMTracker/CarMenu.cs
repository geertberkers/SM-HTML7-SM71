using System.Collections.Generic;
using Xamarin.Forms;

namespace KMTracker
{
	public class CarMenu : ContentPage
	{
		List<Car> cars;
		Button addCarButton;
		RestService restService;
		DataTemplate dataTemplate;
		ListView listView;
		ActivityIndicator indicator;
		Label carsLabel;

		public CarMenu()
		{
			Padding = new Thickness(20);

			restService = new RestService();

			getCars();

			dataTemplate = new DataTemplate(typeof(CarCell));

		 	listView = new ListView
			{
				ItemsSource = cars,
				ItemTemplate = dataTemplate
			};

			listView.ItemTapped += (s, e) =>
			{
				Application.Current.MainPage = new CarView(this, (Car)e.Item);
				listView.SelectedItem = null;
			};

			listView.ItemSelected += (s, e) =>
			{
				listView.SelectedItem = null;
			};

			addCarButton = new Button();
			addCarButton.Text = "Add Car";
			addCarButton.Clicked += (s, e) => AddCarButtonClicked();

		 	indicator = new ActivityIndicator() { IsRunning = true, Color = Color.Red };
			carsLabel = new Label { Text = "Loading cars" };
			//carsLabel.IsVisible = false;
			carsLabel.FontSize = 24;
			carsLabel.HorizontalOptions = LayoutOptions.Center;
			carsLabel.FontAttributes = FontAttributes.Bold;

			var view = new StackLayout
			{
				Children = {
					carsLabel,
					indicator,
					listView,
					addCarButton
				}
			};

			Content = view;
		}

		async void getCars()
		{
			cars = await restService.GetCarsAsync();
			listView.ItemsSource = cars;
			listView.ItemTemplate = dataTemplate;
			indicator.IsRunning = false;
			indicator.IsVisible = false;
			carsLabel.Text = "Select a car:";
		}

		internal void AddCar(Car car)
		{
			// Todo: add to server
			// http://localhost:1337/car/create?name=Opel%20Astra&numberPlate=99-ABC-9&mileAge=12&ritten=1
			cars.Add(car);
		}

		void AddCarButtonClicked()
		{
			Application.Current.MainPage = new AddCar(this);
		}
	}
}

