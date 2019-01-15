using Foundation;
using System;
using UIKit;

namespace WeatherApp
{
    public partial class SettingsViewController : UITableViewController
    {
        public SettingsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SwitchCelcius.On = false;
            SupportButton.SetTitle( "Code",UIControlState.Normal);
        }
    }
}