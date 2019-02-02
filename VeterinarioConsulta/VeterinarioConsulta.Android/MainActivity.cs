using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android;
using Xamarin.Forms;
using VeterinarioConsulta.Paginas;

namespace VeterinarioConsulta.Droid
{
    [Activity(Label = "VeterinarioConsulta", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        protected override void OnStart()
        {
            base.OnStart();

            string permission = Manifest.Permission.AccessFineLocation;

            if (ContextCompat.CheckSelfPermission(this, permission) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[]
                { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation}, 0);
            }
            else
            {
                System.Diagnostics.Debug.Print("Permissão concedida");
            }
        }

        public override void OnBackPressed()
        {
            var mainpage = App.Current.MainPage;
            var home = (mainpage.Navigation.NavigationStack[0] as Home);
            var itensNavigation = mainpage.Navigation.NavigationStack.Count;
            if (itensNavigation > 1)
            {
                mainpage.Navigation.PopAsync();
            }
            else if (itensNavigation == 1 && home.Tipo() != typeof(Mapa).ToString())
            {
                home.Voltar(); 
            }
            else
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                }
            }
        }

    }
}