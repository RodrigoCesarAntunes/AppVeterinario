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

[assembly: ExportRenderer(typeof(TextBoxPadrao), typeof(TextBoxPadraoRenderer))]
namespace VeterinarioConsulta.Droid.Renderers
{
    class TextBoxPadraoRenderer: EntryRenderer
    {
        
        public TextBoxPadraoRenderer(Context context)
            : base(context)
        {}

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var TextBoxPadrao = (TextBoxPadrao)Element;
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
            gradientDrawable.SetCornerRadius(50f);
            gradientDrawable.SetStroke(5, CorDaLinha());
            gradientDrawable.SetColor(Android.Graphics.Color.White);

            Control.SetBackground(gradientDrawable);
            Control.SetPadding(40, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);   
        }

        private Android.Graphics.Color CorDaLinha()
        {
            var TextBoxPadrao = (TextBoxPadrao)Element;
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