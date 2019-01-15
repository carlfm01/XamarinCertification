using Foundation;
using System;
using UIKit;

namespace WeatherApp
{
    public partial class WeatherTableCell : UITableViewCell
    {
        public WeatherTableCell (IntPtr handle) : base (handle)
        {
        }

        public void UpdateData(Weather weather)
        {
            TextCity.Text = weather.City;
            TextTempHi.Text = weather.High.ToString();
            TextTempLow.Text = weather.Low.ToString();
            ImageWeather.Image = UIImage.FromBundle(weather.CurrentConditions.ToString().ToLower() + ".png");
        }
    }
}