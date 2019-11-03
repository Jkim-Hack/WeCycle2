using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeCycle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraMain : ContentPage
    {
        public CameraMain()
        {

            InitializeComponent();
            ImageButton takePicture = new ImageButton
            {
                Source = "Oval.png",
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Transparent,
                Margin = new Thickness(0, 0, 0, 20)
            };

            CameraPreview camera = new CameraPreview 
            { 
                Camera = CameraOptions.Rear, 
                HorizontalOptions = LayoutOptions.FillAndExpand, 
                VerticalOptions = LayoutOptions.FillAndExpand 
            };


            Content = new StackLayout
            {
                Children = { new Grid { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand,
                        Children =
                        {
                            camera, takePicture
                        }

                    } 
                }
            };

        }
    }
}