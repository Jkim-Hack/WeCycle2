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
    public partial class Challenges : ContentPage
    {
        public Challenges()
        {
            InitializeComponent();
        }
        void changePg(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    // go back to main page
                    Navigation.PopToRootAsync();
                    break;
                case SwipeDirection.Right:
                    // not supposed to do anything
                    //Navigation.PushAsync(new Challenges());
                    break;

            }
        }
    }
}