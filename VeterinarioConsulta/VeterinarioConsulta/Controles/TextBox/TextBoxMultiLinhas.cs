using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace VeterinarioConsulta.Controles.TextBox
{
    public class TextBoxMultiLinhas : Editor
    {
        public static readonly BindableProperty IsInvalidoProperty =
            BindableProperty.Create<TextBoxPadrao, bool>(
                p => p.IsInvalido, default(bool)
                );

        public bool IsInvalido
        {
            get { return (bool)GetValue(IsInvalidoProperty); }
            set
            {
                SetValue(IsInvalidoProperty, value);
                OnPropertyChanging(nameof(IsInvalido));
            }
        }
    }
}
