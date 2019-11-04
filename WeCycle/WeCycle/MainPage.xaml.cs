using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeCycle
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var label = this.FindByName<Label>("label");
            label.Text = "Main Page";

            //show the sandwich button?
            var butt = this.FindByName<ImageButton>("frends");
            

        }
        //action for clicking the button
        async void OnButtonClicked(object sender, EventArgs args)
        {
            //????action for pressing button
            await label.RelRotateTo(360, 1000);
        }
        void changePg(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    // go to friends page
                    Navigation.PushAsync(new Friends());
                    break;
                case SwipeDirection.Right:
                    // go to challenges page
                    Navigation.PushAsync(new Challenges());
                    break;

            }
        }
        public static NavigationPage Init()
        {
            NavigationPage nav = new NavigationPage(new MainPage());
            return nav;
        }
    }
}
