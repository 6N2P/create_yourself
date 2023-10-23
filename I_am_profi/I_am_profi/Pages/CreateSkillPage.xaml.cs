using I_am_profi.ViewModeks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace I_am_profi.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSkillPage : ContentPage
    {
        public CreateSkillPage( )
        {
            InitializeComponent();
            this.BindingContext = new CreateSkillViewModel();
        }
    }
}