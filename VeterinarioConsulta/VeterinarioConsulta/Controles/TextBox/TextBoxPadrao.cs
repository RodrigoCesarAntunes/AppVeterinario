using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace VeterinarioConsulta.Controles.TextBox
{
    public class TextBoxPadrao: Entry
    {
        public static readonly BindableProperty IsInvalidoProperty =
            BindableProperty.Create(nameof(IsInvalido),typeof(bool), typeof(bool));

        //Create<TextBoxPadrao, bool>(
        //        p => p.IsInvalido, default(bool)
        //        );

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
