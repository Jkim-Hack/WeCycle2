using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//found this on main page (original starting page) so i put this here
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data.SqlClient;



namespace WeCycle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            var back = this.FindByName<Image>("backgrnd");
            var title = this.FindByName<Image>("title");
            var quote = this.FindByName<Label>("quote");
            var divider = this.FindByName<Image>("divide");
            var signIn = this.FindByName<ImageButton>("SignIn");
            var signUp = this.FindByName<ImageButton>("SignUp");

            signUp.Clicked += SignUp_Clicked;
            signIn.Clicked += SignIn_Clicked;

            back.Opacity = 0;
            back.FadeTo(1, 2000);
            title.Opacity = 0;
            title.FadeTo(1, 3000);
            quote.Opacity = 0;
            quote.FadeTo(1, 4000);
            divider.Opacity = 0;
            divider.FadeTo(1, 5000);
            signIn.Opacity = 0;
            signIn.FadeTo(1, 5500);


        }

        void SignIn_Clicked(object sender, EventArgs args)
        {
            Console.WriteLine("If you see this you are gay");
            String userName = UsernameEntry.Text;
            String password = PasswordEntry.Text;


            SqlConnectionStringBuilder sqlStringBuilder = SQLManager.sqlConnectionString("blndhack.database.windows.net", "adminblnd", "Tigerknight!", "HackOhio");

            App.user = SQLManager.readSingleUserData(userName, sqlStringBuilder);

            if (App.user != null)
                Navigation.PushAsync(new CameraMain());
            else
                Console.WriteLine("Invalid account");
            
        }

        void SignUp_Clicked(object sender, EventArgs args)
        {
            Console.WriteLine("If you see this you are gay");
            String userName = UsernameEntry.Text;
            String password = PasswordEntry.Text;


            App.user = new User(userName, password, "000-000-0000", 0, 0, 0);

            SQLManager.insertSingleUser(App.user, App.connectionInfo);

            if (App.user != null)
                Navigation.PushAsync(new CameraMain());
            else
                Console.WriteLine("Invalid account");

        }
    }
}