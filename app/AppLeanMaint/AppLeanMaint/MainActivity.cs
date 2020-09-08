using System;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using AppLeanMaint.Views;

namespace AppLeanMaint
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
			{
				var newExc = new Exception("CurrentDomainOnUnhandledException", e.ExceptionObject as Exception);
				Helpers.Exceptions.LogUnhandledException(newExc);
			};
			TaskScheduler.UnobservedTaskException += (sender, e) =>
			{
				var newExc = new Exception("TaskSchedulerOnUnobservedTaskException", e.Exception as Exception);
				Helpers.Exceptions.LogUnhandledException(newExc);
			};

			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			SetContentView(Resource.Layout.activity_main);
			Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);

			DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
			drawer.AddDrawerListener(toggle);
			toggle.SyncState();

			NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
			navigationView.SetNavigationItemSelectedListener(this);

			if (Helpers.Exceptions.DisplayCrashReport(this) == false)
			{
				Helpers.WS.Instance.UpdateLocalDataAsync();
			}
		}

		protected override void OnPause()
		{
			base.OnPause();
		}

		protected override void OnResume()
		{
			base.OnResume();
		}

		public override void OnBackPressed()
		{
			DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			if (drawer.IsDrawerOpen(GravityCompat.Start))
			{
				drawer.CloseDrawer(GravityCompat.Start);
			}
			else
			{
				base.OnBackPressed();
			}
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu_main, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			int id = item.ItemId;
			if (id == Resource.Id.action_settings)
			{
				return true;
			}

			return base.OnOptionsItemSelected(item);
		}

		public bool OnNavigationItemSelected(IMenuItem item)
		{
			int id = item.ItemId;

			if (id == Resource.Id.nav_executions_operator)
			{
				//StartActivity(typeof(ActivityExecution));
			}
			else if (id == Resource.Id.nav_executions_position)
			{
				//StartActivity(typeof(ActivityExecution));
			}
			else if (id == Resource.Id.nav_executions_map)
			{
				//StartActivity(typeof(ActivityExecution));
			}
			else if (id == Resource.Id.nav_executions_asset)
			{
				//StartActivity(typeof(ActivityExecution));
			}
			else if (id == Resource.Id.nav_plannings_asset)
			{
				StartActivity(typeof(ActivityOrders));
			}
			else if (id == Resource.Id.nav_plannings_list)
			{
				StartActivity(typeof(ActivityOrdersList));
			}

			DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			drawer.CloseDrawer(GravityCompat.Start);
			return true;
		}
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}
}

