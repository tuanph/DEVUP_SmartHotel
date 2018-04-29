using System;
using System.Globalization;

namespace SmartHotel.Models
{
    public class GeoLocation
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public static GeoLocation Parse(string location)
        {
            GeoLocation result = new GeoLocation();

            try
            {
                //var locationSetting = "10.704175, 106.738109";//AppSettings.DefaultFallbackMapsLocation; 10.704175, 106.738109 40.762246,-73.986943
                var locationParts = location.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                result.Latitude = double.Parse(locationParts[0], CultureInfo.InvariantCulture);
                result.Longitude = double.Parse(locationParts[1], CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error parsing location: {ex}");
            }

            return result;
        }
    }
}
