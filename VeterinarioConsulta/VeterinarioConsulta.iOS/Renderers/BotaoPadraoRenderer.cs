using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace VeterinarioConsulta.iOS.Renderers
{
    public class BotaoPadraoRenderer: ButtonRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
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