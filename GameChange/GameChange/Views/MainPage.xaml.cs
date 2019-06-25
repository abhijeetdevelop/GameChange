using GameChange.Services;
using GameChange.ViewModels;
using GameChange.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static GameChange.ViewModels.ViewModelLocator;

namespace GameChange
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();            
        }

        private void Create_Clicked(object sender, EventArgs e)
        {
            NavigationService.GetNavigationService.NavigateTo(NavigatePage.CreateView.ToString(), null);
        }

        private void View_Clicked(object sender, EventArgs e)
        {
            NavigationService.GetNavigationService.NavigateTo(NavigatePage.ListView.ToString(),null);
        }
    }
}
