using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;
using VeterinarioConsulta.Controles.TextBox;
using VeterinarioConsulta.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TextBoxPadrao), typeof(TextBoxPadraoRenderer))]
namespace VeterinarioConsulta.iOS.Renderers
{
    public class TextBoxPadraoRenderer: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Element.PropertyChanged += (o, ar) => DefinirCor();

            if(e.OldElement == null)
            {
                Control.Layer.CornerRadius = 10;
                Control.Layer.BorderWidth = 2f;
                Control.Layer.BorderColor = VerificarValidade();
                //Control.Layer.BackgroundColor = Color.Gray.ToCGColor();

                Control.LeftView = new UIKit.UIView(new CGRect(0, 0, 10, 0));
                //Control.LeftViewMode = new UITextFieldViewMode.Always;
            }
        }

        private CGColor VerificarValidade()
        {
            var TextBoxPadrao = (TextBoxPadrao)Element;
            return TextBoxPadrao.IsInvalido ?
                Color.Red.ToCGColor() : Color.DimGray.ToCGColor();
        }

        private void DefinirCor()
        {
            Control.Layer.BorderColor = VerificarValidade();
        }
    }
}