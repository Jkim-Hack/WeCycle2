using System;
using System.IO;
using Android.App;

using Android.Graphics;

[assembly: Xamarin.Forms.Dependency(typeof(WeCycle.Droid.ScreenshotServiceAndroid))]
namespace WeCycle.Droid
{
    public class ScreenshotServiceAndroid : IScreenshotService
    {
        
            public static Activity Activity { get; set; }

            public byte[] CaptureScreen()
            {
                var view = Activity.Window.DecorView;
                view.DrawingCacheEnabled = true;

                var bitmap = view.GetDrawingCache(true);

                byte[] bitmapData;
                using (var stream = new MemoryStream())
                {
                    Console.WriteLine("EEEEEE");
                    bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                    bitmapData = stream.ToArray();
                }
                Console.WriteLine(bitmapData.Length);

            return bitmapData;
            }
        
    }
}
