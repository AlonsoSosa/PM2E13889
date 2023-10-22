using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2ExamenC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageVoice : ContentPage
    {
        public PageVoice()
        {
            InitializeComponent();
        }

        private async void btnvoz_Clicked(object sender, EventArgs e)
        {
            await SpeakNow(texto.Text);
        }

        public async Task SpeakNow(String texto)
        {
            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 1.0f
            };

            await TextToSpeech.SpeakAsync(texto, settings);
        }
    }
}