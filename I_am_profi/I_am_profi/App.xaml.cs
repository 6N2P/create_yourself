using I_am_profi.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace I_am_profi
{
    public partial class App : Application
    {
     
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage( new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
