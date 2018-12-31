using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace VeterinarioConsulta.Controles.Mapa
{
    public class PinCustomizado: Pin
    {
        public int ID { get; set; }
        public Pin Pin { get; set; }
    }
}
