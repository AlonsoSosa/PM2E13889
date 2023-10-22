using PM2ExamenC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2ExamenC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListPerson : ContentPage
    {
        public PageListPerson()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            list.ItemsSource = await App.Instancia.listPersonas();
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private async void ToolbarItem_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageMap());
        }

        private  void btneliminar_Clicked(object sender, EventArgs e)
        {
           
            
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageVoice());
        }
    }
}
