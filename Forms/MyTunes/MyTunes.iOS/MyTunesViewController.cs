using UIKit;
using System.Linq;
namespace MyTunes
{
	public class MyTunesViewController : UITableViewController
	{
		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
		}

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

            SongLoader.Loader = new StreamLoader();
            var data = await SongLoader.Load();

            // Register the TableView's data source
            TableView.Source = new ViewControllerSource<Song>(TableView)
            {
                DataSource = data.ToList(),
                TextProc = s => s.Name,
                DetailTextProc = s => s.Artist + " - " + s.Album,
            };

            //TableView.Source = new ViewControllerSource<string>(TableView) {
            //	DataSource = new string[] { "One", "Two", "Three" },
            //};
        }
	}

}

