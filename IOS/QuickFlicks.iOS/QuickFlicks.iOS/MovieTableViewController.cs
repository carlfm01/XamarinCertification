using Foundation;
using QuickFlicks.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;

namespace QuickFlicks.iOS
{
    public partial class MovieTableViewController : UITableViewController, IUISearchResultsUpdating
    {
        IReadOnlyList<Movie> movies;
        private UISearchController searchController;
        private readonly string CellId = "MovieCell";

        public MovieTableViewController(IntPtr handle) : base(handle)
        {
            searchController = new UISearchController(searchResultsController: null)
            {
                HidesNavigationBarDuringPresentation = false,
                ObscuresBackgroundDuringPresentation = false,
                SearchResultsUpdater = this,
            };
            searchController.SearchBar.Placeholder = "Search movies";
            TableView.TableHeaderView = searchController.SearchBar;
        }
        private async Task UpdateMovieListings(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var movieService = new MovieService();
                movies = await movieService.GetMoviesForSearchAsync(searchTerm);
            }
            else
            {
                movies = null;
            }
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return movies?.Count ?? 0;
        }
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            await UpdateMovieListings("Star Wars");
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellId);
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellId);
            }

            var movie = movies[indexPath.Row];
            cell.TextLabel.Text = movie.Title;
            cell.DetailTextLabel.Text = movie.Description;

            return cell;
        }

        public async void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            var searchTerm = searchController.SearchBar.Text;
            await UpdateMovieListings(searchTerm);
        }
    }
}