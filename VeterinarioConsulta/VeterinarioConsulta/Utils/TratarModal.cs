using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VeterinarioConsulta.Utils
{
    public class TratarModal
    {

        public async Task AbrirModal(PopupPage modal)
        {
            await PopupNavigation.Instance.PushAsync(modal);
        }

        public async Task FecharModal()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        public async Task FecharTodosModais()
        {
            await PopupNavigation.Instance.PopAllAsync(true);
        }

    }
}
