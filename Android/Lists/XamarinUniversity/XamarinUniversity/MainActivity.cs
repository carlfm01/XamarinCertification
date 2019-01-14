using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace XamarinUniversity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ListView instructorList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
             instructorList = FindViewById<ListView>(Resource.Id.instructorListView);
            instructorList.FastScrollEnabled = true;
            instructorList.Adapter = new InstructorAdapter(InstructorData.Instructors);
            instructorList.ItemClick += InstructorList_ItemClick;
        }

        private void InstructorList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var instructor = instructorList.Adapter.GetItem(e.Position).Cast<Instructor>();

            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this);
            dialog.SetMessage(instructor.Name);
            dialog.SetNeutralButton("OK", delegate { });
            dialog.Show();
        }


    }

    public static class ObjectTypeHelper
    {
        public static T Cast<T>(this Java.Lang.Object obj) where T : class
        {
            var propertyInfo = obj.GetType().GetProperty("Instance");
            return propertyInfo == null ? null : propertyInfo.GetValue(obj, null) as T;
        }
    }
}