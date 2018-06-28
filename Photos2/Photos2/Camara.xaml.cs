using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Plugin.Media;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Photos2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Camara : ContentPage
    {
        public Camara()
        {
            InitializeComponent();
        }

        private async void TomarFoto(object sender, EventArgs e)
        {
            var opciones_almacenamiento = new StoreCameraMediaOptions()
            {
                SaveToAlbum = true,
                Name = "MiFoto.jpg",
            };
            var foto = await CrossMedia.Current.TakePhotoAsync(opciones_almacenamiento);
            MiImagen.Source = ImageSource.FromStream(() =>
            {
                var stream = foto.GetStream();
                foto.Dispose();
                return stream;
            });
        }
        private async void Elegir(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                var imagen = await CrossMedia.Current.PickPhotoAsync();
                if (imagen != null)
                {
                    MiImagen.Source = ImageSource.FromStream(() =>
                    {
                        var stream = imagen.GetStream();
                        imagen.Dispose();
                        return stream;
                    });
                }
            }
        }
    }
}