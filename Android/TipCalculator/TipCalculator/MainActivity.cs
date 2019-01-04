using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace TipCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText inputBill;
        Button calculateButton;
        TextView outputTip;
        TextView outputTotal;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            calculateButton.Click += InputBill_Click;
        }

        private void InputBill_Click(object sender, System.EventArgs e)
        {
            string text = inputBill.Text;
            var bill = double.Parse(text);
            var tip = bill * 0.15;
            var total = bill + tip;
            outputTip.Text = tip.ToString();
            outputTotal.Text = total.ToString();
        }
    }
}

