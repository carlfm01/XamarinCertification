using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;

namespace Intents
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _buttonEditContact;
        private TextView _userNameTextView;
        private TextView _emailTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            _buttonEditContact = FindViewById<Button>(Resource.Id.ButtonEditContact);
            _userNameTextView = FindViewById<TextView>(Resource.Id.UsernameTextView);
            _emailTextView = FindViewById<TextView>(Resource.Id.EmailTextView);
            _buttonEditContact.Click += _buttonEditContact_Click;

            _emailTextView.Text = "test@test.test";
            _userNameTextView.Text = "Carlos";
        }

        private void _buttonEditContact_Click(object sender, System.EventArgs e)
        {
            //StartActivity(typeof(ContactEditActivity));
            var intent = new Intent(this, typeof(ContactEditActivity));
            intent.PutExtra("Name", "Carlos");
            intent.PutExtra("Email", "test@test.test");
            StartActivityForResult(intent, 506);
        }


        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                _emailTextView.Text = data.GetStringExtra("Email");
                _userNameTextView.Text = data.GetStringExtra("Name");
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}