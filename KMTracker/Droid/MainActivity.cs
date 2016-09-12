using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace KMTracker.Droid
{
	[Activity(Label = "KMTracker.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			// Init Xamarin Forms
			Xamarin.Forms.Forms.Init(this, bundle);

			// Init Maps
			Xamarin.FormsMaps.Init(this, bundle);

			// Set Screen Width and Height
			App.ScreenWidth = (Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
			App.ScreenHeight = (Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);

			LoadApplication(new App());
		}
	}
}

