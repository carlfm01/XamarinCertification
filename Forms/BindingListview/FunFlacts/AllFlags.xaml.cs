using FlagData;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunFlacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllFlags : ContentPage
    {
        bool isEditing;
        ToolbarItem cancelEditButton;
        public AllFlags()
        {
            InitializeComponent();
            BindingContext = DependencyService.Get<FunFlactsViewModel>();
            cancelEditButton = (ToolbarItem)Resources[nameof(cancelEditButton)];
        }
        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!isEditing)
            {
                DependencyService.Get<FunFlactsViewModel>().CurrentFlag = (Flag)e.Item;
                await Navigation.PushAsync(new FlagDetailsPage());
            }

        }
        private void OnEdit(object sender, EventArgs e)
        {
            var tbItem = sender as ToolbarItem;
            isEditing = (tbItem == editButton);

            ToolbarItems.Remove(tbItem);
            ToolbarItems.Add(isEditing ? cancelEditButton : editButton);
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (isEditing)
            {
                var flag = (Flag)e.SelectedItem;
                if (flag != null && await DisplayAlert("Confirm",
                          $"Are you sure you want to delete {flag.Country}?", "Yes", "No"))
                {
                    DependencyService.Get<FunFlactsViewModel>()
                           .Flags.Remove(flag);
                }
                // Reset the edit button
                OnEdit(cancelEditButton, EventArgs.Empty);
            }
        }
        private async void OnRefreshing(object sender, EventArgs e)
        {
            try
            {
                var collection = DependencyService.Get<FunFlactsViewModel>().Flags;
                int i = collection.Count - 1, j = 0;
                while (i > j)
                {
                    var temp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = temp;
                    i--; j++;
                    await System.Threading.Tasks.Task.Delay(200); // make it take some time.
                }
            }
            finally
            {
                ((ListView)sender).IsRefreshing = false;
            }
        }
    }
}