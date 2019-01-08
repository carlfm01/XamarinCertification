using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;

namespace Clock
{
    [Activity(Label = "Clock", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Android.Support.V4.App.FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            var fragments = new Android.Support.V4.App.Fragment[]
{
   new TimeFragment(),
   new StopwatchFragment(),
   new AboutFragment()
};
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            var titles = CharSequence.ArrayFromStringArray(new[] { "Time", "Stopwatch", "About" });
            var adapter = new ClockAdapter(SupportFragmentManager, fragments,titles);
            var viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPager.Adapter = adapter;
            var tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);
            tabLayout.SetupWithViewPager(viewPager);
            tabLayout.GetTabAt(0).SetIcon(Resource.Drawable.ic_access_time_white_24dp);
            tabLayout.GetTabAt(1).SetIcon(Resource.Drawable.ic_timer_white_24dp);
            tabLayout.GetTabAt(2).SetIcon(Resource.Drawable.ic_info_outline_white_24dp);
        }
    }
}