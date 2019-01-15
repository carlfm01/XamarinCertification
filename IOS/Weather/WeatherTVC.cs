using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace WeatherApp
{
    partial class WeatherTVC : UITableViewController
	{
		const string CELL_ID = "id";
		List<Weather> data;
        IGrouping<char, Weather>[] grouping;
        string[] indices;
        public WeatherTVC (IntPtr handle) : base (handle)
		{
            data = WeatherFactory.GetWeatherData();
            grouping = (from w in data
                        orderby w.City[0] ascending
                        group w by w.City[0] into g
                        select g).ToArray();
            indices = (from s in data
                       orderby s.City ascending
                       group s by s.City[0] into g
                       select g.Key.ToString()).ToArray();
            //TableView.RegisterClassForCellReuse(typeof(WeatherCell), CELL_ID);
        }
       
        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
            var cell = (WeatherTableCell)tableView.DequeueReusableCell("cell_id");
            var weather = grouping[indexPath.Section].ElementAt(indexPath.Row);

            cell.UpdateData(weather);
            return cell;

        }

		
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return grouping[section].Count();
        }
        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return grouping[section].Key.ToString();
        }

        public override string TitleForFooter(UITableView tableView, nint section)
        {
            return "Number of Cities: " + grouping[section].Count().ToString();
        }
        public override string[] SectionIndexTitles(UITableView tableView)
        {
            return indices;
        }
        public override nint NumberOfSections(UITableView tableView)
        {
            return grouping.Length;
        }

    }
}
