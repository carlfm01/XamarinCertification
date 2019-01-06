
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace Intents
{
    [Activity(Label = "ContactsActivity")]
    public class ContactEditActivity : AppCompatActivity
    {
        private TextView _userNameTextView;
        private TextView _emailTextView;
        private EditText _userNameEditText;
        private EditText _userEmailEditText;
        private Button _saveContactButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ContactEdit);
            _emailTextView = FindViewById<TextView>(Resource.Id.EmailTextView);
            _userNameTextView = FindViewById<TextView>(Resource.Id.NameTextView);
            _userNameEditText = FindViewById<EditText>(Resource.Id.PersonNameEditText);
            _userEmailEditText = FindViewById<EditText>(Resource.Id.EmailEditText);
            _saveContactButton = FindViewById<Button>(Resource.Id.ButtonSaveContact);
            _saveContactButton.Click += _saveContactButton_Click;
            _userNameEditText.Text = Intent.GetStringExtra("Name");
            _userEmailEditText.Text = Intent.GetStringExtra("Email");
            // Create your application here
        }

        private void _saveContactButton_Click(object sender, System.EventArgs e)
        {
            var resultIntent = new Intent();
            resultIntent.PutExtra("Name", _userNameEditText.Text);
            resultIntent.PutExtra("Email", _userEmailEditText.Text);
            SetResult(Result.Ok, resultIntent);
            Finish();
        }
    }
}