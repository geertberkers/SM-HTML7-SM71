using Xamarin.Forms;

namespace KMTracker
{
	public class App : Application
	{
		public static double ScreenWidth { get; set; }
		public static double ScreenHeight { get; set; }

		public App()
		{			
			// The root page of your application
			MainPage = new CarMenu();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

