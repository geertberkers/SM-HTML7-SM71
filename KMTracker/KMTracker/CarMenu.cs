using System.Collections.Generic;
using Xamarin.Forms;

namespace KMTracker
{
	public class CarMenu : ContentPage
	{
		List<Car> cars;
		Button addCarButton;

		public CarMenu()
		{
			Padding = new Thickness(20);

			cars = new List<Car> {
				new Car("Opel Astra", "99-ABC-0", 161000.0),
				new Car("Opel Vectra", "77-LH-SL", 221000.0),
				new Car("Peugeot 206", "49-NX-JV", 125000.0),
				new Car("Peugeot 206", "84-RR-HK", 63000.0),
				new Car("Peugeot 207", "AA-123-A", 160000.0)
			};

			var dataTemplate = new DataTemplate(typeof(CarCell));

			var listView = new ListView
			{
				ItemsSource = cars,
				ItemTemplate = dataTemplate
			};

			listView.ItemSelected += (s, e) =>
			{
				//var carView = new CarView(this, (Car)e.SelectedItem);
				//Navigation.PushModalAsync(carView, false);
				Application.Current.MainPage = new CarView(this, (Car)e.SelectedItem);
				//listView.SelectedItem = null;
			};

			addCarButton = new Button();
			addCarButton.Text = "Add Car";
			addCarButton.Clicked += (s, e) => AddCarButtonClicked();

			var view = new StackLayout
			{
				Children = {
					listView,
					addCarButton
				}
			};

			Content = view;
		}

		internal void AddCar(Car car)
		{
			cars.Add(car);
		}

		void AddCarButtonClicked()
		{
			Application.Current.MainPage = new AddCar(this);
		}
	}
}

