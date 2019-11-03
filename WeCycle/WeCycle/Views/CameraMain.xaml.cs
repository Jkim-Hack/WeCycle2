using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace WeCycle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraMain : ContentPage
    {
        public CameraMain()
        {

            InitializeComponent();
            var welcomeLabel = this.FindByName<Label>("Welcome");
            welcomeLabel.Text = "Welcome " + App.user.User_Name;
            var coinsLabel = this.FindByName<Label>("coins");
            coinsLabel.Text = "" + App.user.User_CoinCount;
        }

        async void CaptureSend(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());
            if(photo != null)
            {
                await Task.Run(() => CaptureAndSendScreen(photo));
            }
        }

        async Task CaptureAndSendScreen(MediaFile file)
        {
            var endpoint = new CustomVisionPredictionClient
            {
                ApiKey = KeyService.PredictionKey,
                Endpoint = KeyService.Endpoint

            };

            Console.WriteLine(endpoint.ApiKey);

            var result = await endpoint.ClassifyImageAsync(Guid.Parse(KeyService.ProjectId), KeyService.PublishName, file.GetStream());
            List<PredictionModel> res = result.Predictions.Where(p => p.Probability > .9).ToList();
            foreach (PredictionModel model in res)
            {
                if(model.Probability > .9)
                {
                    Console.WriteLine("RECYCLABLE!");
                    App.user = new User(App.user.User_Name, App.user.User_Password, App.user.User_Email, App.user.User_PhoneNumber, App.user.User_CoinCount+2, App.user.User_Num_ChallengeCompleted);
                    SQLManager.insertSingleUser(App.user, App.connectionInfo);
                } else
                {
                    Console.WriteLine("NOT RECYCLABLE!");
                }
            }

        }

    }
}