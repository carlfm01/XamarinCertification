using CoreGraphics;
using Foundation;
using Mailbox;
using System;
using UIKit;

namespace MailBox
{
    class EmailServerDataSource : UITableViewSource
    {
        EmailServer emailServer = new EmailServer();
        UITableViewController owner;

        public EmailServerDataSource(UITableViewController owner)
        {
            this.owner = owner;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return emailServer.Email.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Create the View Controller in the Main storyboard.
            var storyboard = UIStoryboard.FromName("Main", null);
            var detailViewController =
                 (DetailsViewController)storyboard.InstantiateViewController(
                    "DetailsViewController");

            // Set the email details
            var emailItem = emailServer.Email[indexPath.Row];
            detailViewController.Item = emailItem;

            // Show the new page as a "modal"
            owner.ShowDetailViewController(detailViewController, owner);
        }
        const string cellId = "cell";
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellId);
            if (cell == null)
            {
                cell = new UITableViewCell(CGRect.Empty);
            }
            var item = emailServer.Email[indexPath.Row];
            cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
            cell.TextLabel.Text = item.Subject;
            return cell;
        }

        public override void AccessoryButtonTapped(UITableView tableView,
                                           NSIndexPath indexPath)
        {
            var emailItem = emailServer.Email[indexPath.Row];

            var controller = UIAlertController.Create("Email Details",
                                 emailItem.ToString(), UIAlertControllerStyle.Alert);
            controller.AddAction(UIAlertAction.Create("OK",
                                 UIAlertActionStyle.Default, null));

            owner.PresentViewController(controller, true, null);
        }
    }

    public partial class TableViewController : UITableViewController
    {
        EmailServer emailServer = new EmailServer();

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return emailServer.Email.Count;
        }
        public TableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.Source = new EmailServerDataSource(this);
        }

        public override UITableViewCell GetCell(UITableView tableView,
                                        NSIndexPath indexPath)
        {
            UITableViewCell cell = new UITableViewCell(CGRect.Empty);
            var item = emailServer.Email[indexPath.Row];

            cell.TextLabel.Text = item.Subject;
            return cell;
        }
    }
}