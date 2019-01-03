using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VeterinarioConsulta.Controles.TextBox;
using VeterinarioConsulta.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(TextBoxMultiLinhas), typeof(TextBoxMultiLinhasRenderer))]
namespace VeterinarioConsulta.Droid.Renderers
{

    public class TextBoxMultiLinhasRenderer : EditorRenderer
    {
        public TextBoxMultiLinhasRenderer(Context context)
           : base(context)
        { }
        
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            Element.PropertyChanged += (s, ar) => DefinirCor();
            if (e.OldElement == null)
            {
                FormatarControle();
            }
        }



        private void FormatarControle()
        {
            if (Control == null)
                return;

            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetCornerRadius(20);
            gradientDrawable.SetStroke(5, CorDaLinha());
            gradientDrawable.SetColor(Android.Graphics.Color.White);

            Control.SetBackground(gradientDrawable);
            Control.SetPadding(30, 15, Control.PaddingRight, 10);
        }

        private Android.Graphics.Color CorDaLinha()
        {
            var TextBoxPadrao = (TextBoxMultiLinhas)Element;
            return TextBoxPadrao.IsInvalido ?
                Android.Graphics.Color.Tomato : Android.Graphics.Color.DimGray;
        }

        private void DefinirCor()
        {
            if (Control == null)
                return;

            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetStroke(5, CorDaLinha());
            Control.SetBackground(gradientDrawable);
        }
    }
}