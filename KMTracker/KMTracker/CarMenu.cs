using System;
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

			GenerateTestData();

			var dataTemplate = new DataTemplate(typeof(CarCell));

			var listView = new ListView
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

			var view = new StackLayout
			{
				Children = {
					listView,
					addCarButton
				}
			};

			Content = view;
		}

		void GenerateTestData()
		{
			cars = new List<Car> {
				new Car("Opel Astra", "99-ABC-0", 161000.0),
				new Car("Opel Vectra", "77-LH-SL", 221000.0),
				new Car("Peugeot 206", "49-NX-JV", 125000.0),
				new Car("Peugeot 206", "84-RR-HK", 63000.0),
				new Car("Peugeot 207", "AA-123-A", 160000.0)
			};

			List<Coordinate> coordinates = new List<Coordinate>();

			coordinates.Add(new Coordinate(51.45088348, 5.48007411));
			coordinates.Add(new Coordinate(51.45088128, 5.47999202));
			coordinates.Add(new Coordinate(51.45088771, 5.47992154));
			coordinates.Add(new Coordinate(51.45089593, 5.47984043));
			coordinates.Add(new Coordinate(51.45090508, 5.47976078));
			coordinates.Add(new Coordinate(51.45090595, 5.47966974));
			coordinates.Add(new Coordinate(51.45090752, 5.47958049));
			coordinates.Add(new Coordinate(51.45092336, 5.47949097));
			coordinates.Add(new Coordinate(51.45093725, 5.47935566));
			coordinates.Add(new Coordinate(51.45094971, 5.47924959));
			coordinates.Add(new Coordinate(51.45096427, 5.47916003));
			coordinates.Add(new Coordinate(51.4509753, 5.47906329));
			coordinates.Add(new Coordinate(51.45097948, 5.47895084));
			coordinates.Add(new Coordinate(51.45097888, 5.47886227));
			coordinates.Add(new Coordinate(51.45100286, 5.47879624));
			coordinates.Add(new Coordinate(51.45100718, 5.47869694));
			coordinates.Add(new Coordinate(51.45099993, 5.47860293));
			coordinates.Add(new Coordinate(51.45097412, 5.47850292));
			coordinates.Add(new Coordinate(51.45096141, 5.47838133));
			coordinates.Add(new Coordinate(51.45094441, 5.47827576));
			coordinates.Add(new Coordinate(51.45092534, 5.4781907));
			coordinates.Add(new Coordinate(51.45089377, 5.47807935));
			coordinates.Add(new Coordinate(51.45085547, 5.4780119));
			coordinates.Add(new Coordinate(51.45078338, 5.47797298));
			coordinates.Add(new Coordinate(51.45072236, 5.47795354));
			coordinates.Add(new Coordinate(51.45066236, 5.47793952));
			coordinates.Add(new Coordinate(51.45060434, 5.47791868));
			coordinates.Add(new Coordinate(51.45053667, 5.47790253));
			coordinates.Add(new Coordinate(51.45047303, 5.47788588));
			coordinates.Add(new Coordinate(51.45041606, 5.47787293));
			coordinates.Add(new Coordinate(51.4503557, 5.4778614));
			coordinates.Add(new Coordinate(51.45029676, 5.47784611));
			coordinates.Add(new Coordinate(51.45023755, 5.47785145));
			coordinates.Add(new Coordinate(51.45017525, 5.47784517));
			coordinates.Add(new Coordinate(51.4501164, 5.47784196));
			coordinates.Add(new Coordinate(51.45005631, 5.4778346));
			coordinates.Add(new Coordinate(51.45000471, 5.47781078));
			coordinates.Add(new Coordinate(51.44994342, 5.4778003));
			coordinates.Add(new Coordinate(51.44987817, 5.47779237));
			coordinates.Add(new Coordinate(51.44982213, 5.47777987));
			coordinates.Add(new Coordinate(51.44976926, 5.47775954));
			coordinates.Add(new Coordinate(51.44970151, 5.47773489));
			coordinates.Add(new Coordinate(51.44962673, 5.47771948));
			coordinates.Add(new Coordinate(51.44956209, 5.47771576));
			coordinates.Add(new Coordinate(51.4495011, 5.47772121));
			coordinates.Add(new Coordinate(51.44942829, 5.47772167));
			coordinates.Add(new Coordinate(51.44935607, 5.47772069));
			coordinates.Add(new Coordinate(51.44928189, 5.47770737));
			coordinates.Add(new Coordinate(51.44921431, 5.47767812));
			coordinates.Add(new Coordinate(51.44916178, 5.47766835));
			coordinates.Add(new Coordinate(51.44908803, 5.47765817));
			coordinates.Add(new Coordinate(51.44901611, 5.47763781));
			coordinates.Add(new Coordinate(51.44895145, 5.47763631));
			coordinates.Add(new Coordinate(51.44889832, 5.47761797));
			coordinates.Add(new Coordinate(51.44884279, 5.47761276));
			coordinates.Add(new Coordinate(51.44878065, 5.47758066));
			coordinates.Add(new Coordinate(51.44872174, 5.47756622));
			coordinates.Add(new Coordinate(51.44865137, 5.47756486));
			coordinates.Add(new Coordinate(51.44859378, 5.47755368));
			coordinates.Add(new Coordinate(51.44852361, 5.47753347));
			coordinates.Add(new Coordinate(51.44846673, 5.4775252));
			coordinates.Add(new Coordinate(51.44840519, 5.47751434));
			coordinates.Add(new Coordinate(51.44832807, 5.47749144));
			coordinates.Add(new Coordinate(51.44826359, 5.47748293));
			coordinates.Add(new Coordinate(51.44819844, 5.47747623));
			coordinates.Add(new Coordinate(51.44813667, 5.47747065));
			coordinates.Add(new Coordinate(51.44808534, 5.47745061));
			coordinates.Add(new Coordinate(51.44801493, 5.47744243));
			coordinates.Add(new Coordinate(51.44795107, 5.47742972));
			coordinates.Add(new Coordinate(51.44787528, 5.47738419));
			coordinates.Add(new Coordinate(51.44782356, 5.47736173));
			coordinates.Add(new Coordinate(51.44776298, 5.47735856));
			coordinates.Add(new Coordinate(51.44766137, 5.47732859));
			coordinates.Add(new Coordinate(51.44760081, 5.47732436));
			coordinates.Add(new Coordinate(51.44754217, 5.47732607));
			coordinates.Add(new Coordinate(51.44749363, 5.47732269));
			coordinates.Add(new Coordinate(51.44744128, 5.47732816));
			coordinates.Add(new Coordinate(51.44738351, 5.47733737));
			coordinates.Add(new Coordinate(51.44734066, 5.47731695));
			coordinates.Add(new Coordinate(51.44725493, 5.47731899));
			coordinates.Add(new Coordinate(51.44720856, 5.47730285));
			coordinates.Add(new Coordinate(51.44711657, 5.47730165));
			coordinates.Add(new Coordinate(51.44704438, 5.47729384));
			coordinates.Add(new Coordinate(51.44696538, 5.47728207));
			coordinates.Add(new Coordinate(51.4468881, 5.47726753));
			coordinates.Add(new Coordinate(51.44683521, 5.47729064));
			coordinates.Add(new Coordinate(51.44677993, 5.47727991));
			coordinates.Add(new Coordinate(51.44673481, 5.47727897));
			coordinates.Add(new Coordinate(51.44666463, 5.47725801));
			coordinates.Add(new Coordinate(51.44661925, 5.47725223));
			coordinates.Add(new Coordinate(51.44655559, 5.47724443));
			coordinates.Add(new Coordinate(51.44649951, 5.47723409));
			coordinates.Add(new Coordinate(51.4464335, 5.47723373));
			coordinates.Add(new Coordinate(51.44638369, 5.47722648));
			coordinates.Add(new Coordinate(51.44633316, 5.47721314));
			coordinates.Add(new Coordinate(51.44627678, 5.47719051));
			coordinates.Add(new Coordinate(51.44618851, 5.4771739));
			coordinates.Add(new Coordinate(51.44610674, 5.47716724));
			coordinates.Add(new Coordinate(51.44603561, 5.47715955));
			coordinates.Add(new Coordinate(51.44596533, 5.4771504));
			coordinates.Add(new Coordinate(51.44588251, 5.47716085));
			coordinates.Add(new Coordinate(51.44579957, 5.47715904));
			coordinates.Add(new Coordinate(51.44570599, 5.47715105));
			coordinates.Add(new Coordinate(51.44563082, 5.47715478));
			coordinates.Add(new Coordinate(51.44557169, 5.47715076));
			coordinates.Add(new Coordinate(51.44551126, 5.47715401));
			coordinates.Add(new Coordinate(51.44543578, 5.47715308));
			coordinates.Add(new Coordinate(51.44537073, 5.47716376));
			coordinates.Add(new Coordinate(51.44530419, 5.47716486));
			coordinates.Add(new Coordinate(51.44524103, 5.47718121));
			coordinates.Add(new Coordinate(51.44516927, 5.47718345));
			coordinates.Add(new Coordinate(51.44504492, 5.47721769));
			coordinates.Add(new Coordinate(51.44496114, 5.47722612));
			coordinates.Add(new Coordinate(51.44485761, 5.47723304));
			coordinates.Add(new Coordinate(51.44476133, 5.47723679));
			coordinates.Add(new Coordinate(51.44467145, 5.47727782));
			coordinates.Add(new Coordinate(51.44459726, 5.47731474));
			coordinates.Add(new Coordinate(51.4445272, 5.47734685));
			coordinates.Add(new Coordinate(51.44447758, 5.47735262));
			coordinates.Add(new Coordinate(51.44440842, 5.47738112));
			coordinates.Add(new Coordinate(51.44436641, 5.47738327));
			coordinates.Add(new Coordinate(51.44429653, 5.47740814));
			coordinates.Add(new Coordinate(51.44423709, 5.4774254));
			coordinates.Add(new Coordinate(51.44419664, 5.47747036));
			coordinates.Add(new Coordinate(51.44414203, 5.47750536));
			coordinates.Add(new Coordinate(51.44407628, 5.47753846));
			coordinates.Add(new Coordinate(51.44401697, 5.47756278));
			coordinates.Add(new Coordinate(51.4439751, 5.47756916));
			coordinates.Add(new Coordinate(51.44393887, 5.47756506));
			coordinates.Add(new Coordinate(51.44391748, 5.4775663));
			coordinates.Add(new Coordinate(51.44388502, 5.47757252));
			coordinates.Add(new Coordinate(51.44385782, 5.47758792));
			coordinates.Add(new Coordinate(51.44381796, 5.47760612));
			coordinates.Add(new Coordinate(51.44380054, 5.47761339));
			coordinates.Add(new Coordinate(51.44378009, 5.47762778));
			coordinates.Add(new Coordinate(51.44375833, 5.4776645));
			coordinates.Add(new Coordinate(51.44372922, 5.47768691));
			coordinates.Add(new Coordinate(51.44369249, 5.4777084));
			coordinates.Add(new Coordinate(51.44365875, 5.47773078));
			coordinates.Add(new Coordinate(51.44363326, 5.47776524));

			List<Coordinate> reversedOrder = new List<Coordinate>();
			coordinates.Reverse();
			reversedOrder.AddRange(coordinates);
			coordinates.Reverse();

			foreach(Car car in cars){
				car.Ritten.Add(new Rit("School -> Station", coordinates));
				coordinates.Reverse();
				car.Ritten.Add(new Rit("Station -> School", reversedOrder));
				coordinates.Reverse();
			}
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

