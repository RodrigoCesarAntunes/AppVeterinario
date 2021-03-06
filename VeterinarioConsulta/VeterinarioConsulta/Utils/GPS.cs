﻿using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VeterinarioConsulta.Utils
{
    public class GPS
    {
        public bool IsLocalizacaoDisponivel()
        {
            if (!CrossGeolocator.IsSupported)
                return false;

            return CrossGeolocator.Current.IsGeolocationAvailable;
        }

        public async Task<Position> ObterLocalizacaoAtual()
        {
                Position position = null;
                try
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 100;

                    position = await locator.GetLastKnownLocationAsync();

                    if (position != null)
                    {
                        //got a cahched position, so let's use it.
                        return position;
                    }

                    if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                    {
                        //not available or enabled
                        return null;
                    }

                    position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Erro ao obter localização: " + ex);
                }

                if (position == null)
                    return null;

                var output = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                        position.Timestamp, position.Latitude, position.Longitude,
                        position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

                System.Diagnostics.Debug.WriteLine(output);

                return position;
        }
        
    }
}
