﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using SmartHotel.Controls;
using SmartHotel.Helpers;
using SmartHotel.Models;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(SmartHotel.Droid.Renderers.CustomMapRenderer))]
namespace SmartHotel.Droid.Renderers
{
    public class CustomMapRenderer : MapRenderer
    {
        private const int EventResource = Resource.Drawable.pushpin_01;
        private const int RestaurantResource = Resource.Drawable.pushpin_02;

        private Android.Gms.Maps.Model.BitmapDescriptor _pinIcon;
        private List<CustomMarkerOptions> _tempMarkers;
        private bool _isDrawnDone;
        public CustomMapRenderer()
        {
            _tempMarkers = new List<CustomMarkerOptions>();
            _pinIcon = Android.Gms.Maps.Model.BitmapDescriptorFactory.FromResource(EventResource);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var androidMapView = (MapView)Control;
            var formsMap = (CustomMap)sender;

            if (e.PropertyName.Equals("CustomPins") && !_isDrawnDone)
            {
                ClearPushPins(androidMapView);

                NativeMap.MyLocationEnabled = formsMap.MyLocationEnabled;

                AddPushPins(androidMapView, formsMap.CustomPins);

                PositionMap();

                _isDrawnDone = true;
            }
        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (changed)
            {
                _isDrawnDone = false;
            }
        }

        private void ClearPushPins(MapView mapView)
        {
            NativeMap.Clear();
        }

        private void AddPushPins(MapView mapView, IEnumerable<CustomPin> pins)
        {
            foreach (var formsPin in pins)
            {
                var markerWithIcon = new MarkerOptions();

                markerWithIcon.SetPosition(new LatLng(formsPin.Position.Latitude, formsPin.Position.Longitude));
                markerWithIcon.SetTitle(formsPin.Label);
                markerWithIcon.SetSnippet(formsPin.Address);

                switch (formsPin.Type)
                {
                    case SuggestionType.Event:
                        _pinIcon = Android.Gms.Maps.Model.BitmapDescriptorFactory.FromResource(EventResource);
                        markerWithIcon.SetIcon(_pinIcon);
                        break;
                    case SuggestionType.Restaurant:
                        _pinIcon = Android.Gms.Maps.Model.BitmapDescriptorFactory.FromResource(RestaurantResource);
                        markerWithIcon.SetIcon(_pinIcon);
                        break;
                    default:
                        markerWithIcon.SetIcon(Android.Gms.Maps.Model.BitmapDescriptorFactory.DefaultMarker());
                        break;
                }

                NativeMap.AddMarker(markerWithIcon);

                _tempMarkers.Add(new CustomMarkerOptions
                {
                    Id = formsPin.Id,
                    MarkerOptions = markerWithIcon
                });
            }
        }

        private void PositionMap()
        {
            var myMap = this.Element as CustomMap;
            var formsPins = myMap.CustomPins;

            if (formsPins == null || formsPins.Count() == 0)
            {
                return;
            }

            var centerPosition = new Position(formsPins.Average(x => x.Position.Latitude), formsPins.Average(x => x.Position.Longitude));

            var minLongitude = formsPins.Min(x => x.Position.Longitude);
            var minLatitude = formsPins.Min(x => x.Position.Latitude);

            var maxLongitude = formsPins.Max(x => x.Position.Longitude);
            var maxLatitude = formsPins.Max(x => x.Position.Latitude);

            var distance = MapHelper.CalculateDistance(minLatitude, minLongitude,
                maxLatitude, maxLongitude, 'M') / 2;

            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(centerPosition, Distance.FromMiles(distance)));
        }
    }
    public class CustomMarkerOptions
    {
        public int Id { get; set; }
        public MarkerOptions MarkerOptions { get; set; }
    }
}