using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VeterinarioConsulta.Controles.Mapa;
using VeterinarioConsulta.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(MapaCustomizado), typeof(MapaCustomizadoRenderer))]
namespace VeterinarioConsulta.Droid.Renderers
{
    public class MapaCustomizadoRenderer: MapRenderer
    {
        private List<PinCustomizado> PinsCustomizados;

        public MapaCustomizadoRenderer(Context context)
            : base(context) { }


        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement != null)
            {
            }
            if(e.NewElement != null)
            {
                var mapa = (MapaCustomizado)e.NewElement;
                PinsCustomizados = mapa.PinsCustomizados;
                Control.GetMapAsync(this);
            }
        }


    }
}