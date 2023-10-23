using I_am_profi.ViewModeks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using I_am_profi.Pages;

namespace I_am_profi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        private async void CreateSkillBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateSkillPage());
        }
    }
}
