using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Recipes
{
    [Activity(Label = "DetailsActivity")]
	public class DetailsActivity : AppCompatActivity
	{
		Recipe recipe;
		ArrayAdapter adapter;
        Android.Support.V7.Widget.Toolbar toolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Details);
            

            // Element lookup
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_arrow_back_white_24dp);
            // toolbar.InflateMenu(Resource.Menu.actions);
            //toolbar.MenuItemClick += Toolbar_MenuItemClick;
            //
            // Retrieve the recipe to be displayed on this page
            //
            int index = Intent.GetIntExtra("RecipeIndex", -1);
            recipe = RecipeData.Recipes[index];

            //
            // Show the recipe name
            //
            toolbar.Title = recipe.Name;

            //
            // Show the list of ingredients
            //
            var list = FindViewById<ListView>(Resource.Id.ingredientsListView);
            list.Adapter = adapter = new ArrayAdapter<Ingredient>(this, Android.Resource.Layout.SimpleListItem1, recipe.Ingredients);

            //
            // Set up the "Favorite" toggle, we use different images for the 'on' and 'off' states
            //

           // SetFavoriteDrawable(recipe.IsFavorite);

            //
            // Set up the "Number of servings" buttons
            //
            //FindViewById<Button>(Resource.Id.oneServingButton).Click += (sender, e) => SetServings(1);
            //FindViewById<Button>(Resource.Id.twoServingsButton).Click += (sender, e) => SetServings(2);
            //FindViewById<Button>(Resource.Id.fourServingsButton).Click += (sender, e) => SetServings(4);

            //
            // Navigation button: navigate back to the previous page
            //
           // FindViewById<ImageButton>(Resource.Id.backButton).Click += (sender, e) => Finish();

            //
            // Navigation button: navigate forward to the About page
            //
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.MenuInflater.Inflate(Resource.Menu.actions, menu);
            SetFavoriteDrawable(recipe.IsFavorite);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    break;
                case Resource.Id.addToFavorites:
                    recipe.IsFavorite = !recipe.IsFavorite;
                    SetFavoriteDrawable(recipe.IsFavorite);
                    break;

                case Resource.Id.about:
                    StartActivity(typeof(AboutActivity));
                    break;

                case Resource.Id.oneServing: SetServings(1); item.SetChecked(true); break;
                case Resource.Id.twoServings: SetServings(2); item.SetChecked(true); break;
                case Resource.Id.fourServings: SetServings(4); item.SetChecked(true); break;
            }

            return true;
        }

        

        

        //
        // Handler for the 'favorite' toggle button
        //
        

		void SetFavoriteDrawable(bool isFavorite)
		{
			//Drawable drawable = null;

            if (isFavorite)
                toolbar.Menu.FindItem(Resource.Id.addToFavorites).SetIcon(Resource.Drawable.ic_favorite_white_24dp); // filled in 'heart' image
            else
                toolbar.Menu.FindItem(Resource.Id.addToFavorites).SetIcon(Resource.Drawable.ic_favorite_border_white_24dp); // 'heart' image border only
                                                                                                                            //FindViewById<ToggleButton>(Resource.Id.favoriteButton).SetCompoundDrawablesWithIntrinsicBounds(null, drawable, null, null);
        }
		// Note: base.GetDrawable requires API level 21
		// To run on earlier versions, change the minimum API level in the project settings and use the following code:
		//void SetFavoriteDrawables(bool isFavorite)
		//{
		//	Drawable drawable = null;
		//
		//	if (isFavorite)
		//		drawable = Resources.GetDrawable(Resource.Drawable.ic_favorite_white_24dp);
		//	else
		//		drawable = Resources.GetDrawable(Resource.Drawable.ic_favorite_border_white_24dp);
		//
		//	FindViewById<ToggleButton>(Resource.Id.favoriteButton).SetCompoundDrawablesWithIntrinsicBounds(null, drawable, null, null);
		//}

		void SetServings(int numServings)
		{
			recipe.NumServings = numServings;

			adapter.NotifyDataSetChanged();
		}
	}
}