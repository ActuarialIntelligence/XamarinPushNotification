using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AndroidX.Core.App;

namespace TestForm.Droid
{
    [Activity(Label = "TestForm", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //CreateNotificationChannel();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }
            var GUID = new Guid();
            var channelDescription = "FirstChannel";
            var channel = new NotificationChannel(GUID.ToString(),"NotifyApp" , NotificationImportance.Default)
            {
                Description = channelDescription
            };

            // Instantiate the builder and set notification elements:
            NotificationCompat.Builder builder = new NotificationCompat.Builder(this, GUID.ToString())
                .SetContentTitle("Notification")
                .SetContentText("This is my first notification!")
                 .SetDefaults(1)
                 .SetSmallIcon(Resource.Drawable.material_ic_menu_arrow_down_black_24dp);

            // Build the notification:
            Notification notification = builder.Build();

            // Get the notification manager:
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);

            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify (notificationId, notification);
        }
    }
}