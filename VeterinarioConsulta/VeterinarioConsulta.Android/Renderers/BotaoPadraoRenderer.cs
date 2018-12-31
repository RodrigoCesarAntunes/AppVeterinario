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
using VeterinarioConsulta.Controles.Botao;
using VeterinarioConsulta.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(BotaoPadrao), typeof(BotaoPadraoRenderer))]
namespace VeterinarioConsulta.Droid.Renderers
{
    public class BotaoPadraoRenderer: ButtonRenderer
    {
        public BotaoPadraoRenderer(Context context)
            : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement == null)
            {
                Element.CornerRadius = 10;
                Element.BackgroundColor = Color.White;
                Element.BorderWidth = 2;
                Element.BorderColor = Color.Black;
            }
        }
    }
}