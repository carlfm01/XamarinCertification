using Xamarin.Forms;

namespace Phoneword
{ 
    class MainPage : ContentPage
    {
        readonly Entry phoneNumberText;
        readonly Button translateButton;
        readonly Button callButton;
        string translatedNumber;
        public MainPage()
        {
            Padding = new Thickness(20, 20, 20, 20);

            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };

            panel.Children.Add(new Label
            {
                Text = "Enter a Phoneword:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "1-855-XAMARIN",
            });

            panel.Children.Add(translateButton = new Button
            {
                Text = "Translate"
            });

            panel.Children.Add(callButton = new Button
            {
                Text = "Call",
                IsEnabled = false,
            });
            translateButton.Clicked += TranslateButton_Clicked;
            callButton.Clicked += CallButton_ClickedAsync;
            Content = panel;
        }

        private async void CallButton_ClickedAsync(object sender, System.EventArgs e)
        {
            if (await DisplayAlert(
                 "Dial a Number",
        "Would you like to call " + translatedNumber + "?",
        "Yes",
        "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    await dialer.DialAsync(translatedNumber); 
                }
            }
        }

        private void TranslateButton_Clicked(object sender, System.EventArgs e)
        {
            string enteredNumber = phoneNumberText.Text;
            translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }
    }
}
