using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeCycle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Challenges : ContentPage
    {
        public Challenges()
        {

            Label header = new Label
            {
                Text = "Challenges",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        new ImageCell
                        {
                            // Some differences with loading images in initial release.
                            ImageSource = "COINS.png",
                            Text = "Daily Challenge 1",
                            Detail = "Scan 3 Items! Reward: 30 coins",
                        }
                    },
                    new TableSection
                    {
                        new ImageCell
                        {
                            // Some differences with loading images in initial release.
                            ImageSource = "COINS.png",
                            Text = "Daily Challenge 2",
                            Detail = "Scan 5 Items! Reward: 50 coins",
                        }
                    },
                    new TableSection
                    {
                        new ImageCell
                        {
                            // Some differences with loading images in initial release.
                            ImageSource = "COINS.png",
                            Text = "Weekly Challenge 1",
                            Detail = "Beat all your friends! Reward: 150 coins",
                        }
                    },
                    new TableSection
                    {
                        new ImageCell
                        {
                            // Some differences with loading images in initial release.
                            ImageSource = "COINS.png",
                            Text = "Goal 1",
                            Detail = "Finish 3 Challenges! Reward: 75 coins",
                        }
                    },
                }
            };
            Label raffles = new Label
            {
                Text = "Raffle",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };


            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    tableView
                }
            };
            //async void Click_Raffle(object sender, EventArgs args)
            //{
            //????action for pressing button
            //await label.RelRotateTo(360, 1000);
            //}
        }
        void changePg(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    // not supposed to do anything
                    Navigation.PopToRootAsync();
                    break;
                case SwipeDirection.Right:
                    // go back to main page
                    break;

            }
        }
    }

}