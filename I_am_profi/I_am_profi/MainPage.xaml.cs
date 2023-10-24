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
            _mainPageviewModel = new MainPageViewModel();
            this.BindingContext = _mainPageviewModel;
        }
        private MainPageViewModel _mainPageviewModel;


        private async void CreateSkillBtn_Clicked(object sender, EventArgs e)
        {
            CreateSkillViewModel createSkillViewModel = new CreateSkillViewModel();
            createSkillViewModel.CreateSkillEvent += _mainPageviewModel.GetSkills;
            await Navigation.PushAsync(new CreateSkillPage(createSkillViewModel));
        }

        private async void EditSkillBtn_Clicked(object sender, EventArgs e)
        {
            if(_mainPageviewModel.SelectedSkill != null)
            {
                EditSkillViewModel editSkillViewModel = new EditSkillViewModel(_mainPageviewModel.SelectedSkill);

                await Navigation.PushAsync(new EditSkillPage(editSkillViewModel));
            }
            
        }
    }
}
