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
            CollectionView collectionView = new CollectionView();
            collectionView.SetBinding(ItemsView.ItemsSourceProperty, "Challeneges");

            collectionView.ItemTemplate = new DataTemplate(() =>
            {
                Grid grid = new Grid { Padding = 10 };
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                Image image = new Image { Aspect = Aspect.AspectFill, HeightRequest = 60, WidthRequest = 60 };
                image.SetBinding(Image.SourceProperty, "ImageUrl");

                Label nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                nameLabel.SetBinding(Label.TextProperty, "Name");

                Label descLabel = new Label { FontAttributes = FontAttributes.Italic, VerticalOptions = LayoutOptions.End };
                descLabel.SetBinding(Label.TextProperty, "Description");

                Grid.SetRowSpan(image, 2);

                grid.Children.Add(image);
                grid.Children.Add(nameLabel, 1, 0);
                grid.Children.Add(descLabel, 1, 1);

                return grid;
            });

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