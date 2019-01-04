using System;
using UIKit;

namespace Fireworks
{
    public partial class ViewController : UIViewController
    {
        
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            OpenAboutButton.TouchUpInside += OpenAboutButton_TouchUpInside;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        private void OpenAboutButton_TouchUpInside(object sender, EventArgs e)
        {
            AboutViewController aboutVC = (AboutViewController)Storyboard.InstantiateViewController("AboutViewController");

            PresentViewController(aboutVC, true, null);
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}