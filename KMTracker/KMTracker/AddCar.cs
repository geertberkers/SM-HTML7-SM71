using Xamarin.Forms;

namespace KMTracker
{
	public class AddCar : ContentPage
	{
		readonly CarMenu menu;

		Entry mileAgeEntry; 
		Entry carNameEntry;
		Entry numberPlateEntry;

		Button addCarButton;

		public AddCar(CarMenu menu)
		{
			this.menu = menu;
			Padding = new Thickness(20);

			mileAgeEntry = new Entry { Keyboard = Keyboard.Numeric, Placeholder = "Mile Age" };
			carNameEntry = new Entry { Text = "Car" };
			numberPlateEntry = new Entry { Text = "NumberPlate" };

			addCarButton = new Button { Text = "Add car" };
			addCarButton.Clicked += (s, e) => CreateCar();

			// For testing, no need to fill these in whole time
			carNameEntry.Text = "TEST";
			numberPlateEntry.Text = "55-TE-ST";
			mileAgeEntry.Text = "100000.0";

			Content = new StackLayout
			{
				Children = {
					carNameEntry,
					numberPlateEntry,
					mileAgeEntry,
					addCarButton
				}
			};
		}

		void CreateCar()
		{
			menu.AddCar(new Car(carNameEntry.Text, numberPlateEntry.Text, double.Parse(mileAgeEntry.Text)));
			Application.Current.MainPage = menu;
		}

		protected override bool OnBackButtonPressed()
		{
			Application.Current.MainPage = menu;

			return true;
			// return base.OnBackButtonPressed() kills application
		}
	}
}