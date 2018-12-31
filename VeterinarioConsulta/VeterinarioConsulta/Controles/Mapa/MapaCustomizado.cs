using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace VeterinarioConsulta.Controles.Mapa
{
    public class MapaCustomizado: Map
    {
        public MapaCustomizado(MapSpan mapSpan)
            :base(mapSpan)
        {}

        public MapaCustomizado()
        {

        }

        public List<PinCustomizado> PinsCustomizados { get; set; }
    }
}
