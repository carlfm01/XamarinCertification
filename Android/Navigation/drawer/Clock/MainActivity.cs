using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;

namespace Clock
{
	[Activity(Label = "Clock", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Android.Support.V7.App.AppCompatActivity
	{
        private DrawerLayout _drawer;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
            var menu = FindViewById<Android.Support.Design.Widget.NavigationView>(Resource.Id.navigationView);
            menu.NavigationItemSelected += Menu_NavigationItemSelected;
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			base.SetSupportActionBar(toolbar);
			SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_white_24dp);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            _drawer = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            Navigate(new TimeFragment());
		}

        private void Menu_NavigationItemSelected(object sender, Android.Support.Design.Widget.NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case Resource.Id.timeMenuItem: Navigate(new TimeFragment()); break;
                case Resource.Id.stopwatchMenuItem: Navigate(new StopwatchFragment()); break;
                case Resource.Id.aboutMenuItem: Navigate(new AboutFragment()); break;
            }

            e.MenuItem.SetChecked(true);
            _drawer.CloseDrawer(Android.Support.V4.View.GravityCompat.End);
        }

        void Navigate(Android.Support.V4.App.Fragment fragment)
		{
			var transaction = base.SupportFragmentManager.BeginTransaction();
			transaction.Replace(Resource.Id.contentFrame, fragment);
			transaction.Commit();
		}

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    _drawer.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    break;
            }
            return true;
        }

    }
}