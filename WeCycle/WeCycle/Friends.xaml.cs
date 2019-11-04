using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCycle.Items;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeCycle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Friends : ContentPage
    {
        public Friends()
        {
            InitializeComponent();
        }
        void changePg(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    // not supposed to do anything
                    break;
                case SwipeDirection.Right:
                    // go back to main page
                    Navigation.PopAsync();
                    break;

            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<FriendItem> listItems = new List<FriendItem>();
            FriendItem listItem = new FriendItem() { FriendName = "  Jeff" };
            FriendItem listItem1 = new FriendItem() { FriendName = " Jane" };
            FriendItem listItem2 = new FriendItem() { FriendName = "Serena" };
            FriendItem listItem3 = new FriendItem() { FriendName = "  John" };
            FriendItem listItem4 = new FriendItem() { FriendName = "  Amy" };
            FriendItem listItem5 = new FriendItem() { FriendName = "Chris" };
            listItems.Add(listItem);
            listItems.Add(listItem1);
            listItems.Add(listItem2);
            listItems.Add(listItem3);
            listItems.Add(listItem4);
            listItems.Add(listItem5);
            collectionList.ItemsSource = listItems;
        }
    }
}