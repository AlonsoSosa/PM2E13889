using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;

using Plugin.Media.Abstractions;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2ExamenC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePerson : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        public String ImageToBase64()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();
                    String base64 = Convert.ToBase64String(data);
                    return base64;
                }
            }
            return null;
        }

        public byte[] ImageToArrayByte()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();

                    return data;
                }
            }
            return null;
        }
        public PagePerson()
        {
            InitializeComponent();
        }
        //*private async void btnfoto_Clicked(object sender, EventArgs e)
        //{
          //  photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
           // {
             //   Directory = "MiApp",
           //     Name = "Foto.jpg",
           //     SaveToAlbum = true
          //  });

            //if (photo != null)
           // {
            //    foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
           // }
        //}

        private async void btnproceso_Clicked(object sender, EventArgs e)
        {
            var person = new Models.Personas
            {
                lactitudes = txtlatitude.Text,
                longitudes = txtlongitud.Text,
                descripciones = txtdescripcion.Text,
                foto = ImageToArrayByte()
            };

            if (await App.Instancia.addPerson(person) > 0)
            {
                await DisplayAlert("Aviso", "Datos Agregados", "OK");
            }
            else
            {
                await DisplayAlert("Alerta", "Ocurrio un error", "OK");
            }
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Comprobar y solicitar permisos de almacenamiento si es necesario (Xamarin.Essentials)
                var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.StorageRead>();
                    if (status != PermissionStatus.Granted)
                    {
                        // Permiso denegado, debes manejar esto de acuerdo a tus necesidades.
                        return;
                    }
                }
                // Utilizar CrossMedia para seleccionar una imagen de la galería
                var mediaOptions = new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium
                };

                var selectedImage = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (selectedImage != null)
                {
                    // El usuario seleccionó una imagen de la galería
                    // Ahora puedes hacer algo con la imagen, como mostrarla en tu aplicación
                    // Por ejemplo, asignarla a un elemento Image
                    foto.Source = ImageSource.FromFile(selectedImage.Path);

                    // Asegúrate de liberar los recursos de la imagen seleccionada cuando hayas terminado
                    selectedImage.Dispose();
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageListPerson());
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {

        }

        private void btnsalir_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}