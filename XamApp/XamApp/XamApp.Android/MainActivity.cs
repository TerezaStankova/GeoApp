﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace XamApp.Droid
{
    [Activity(Label = "XamApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            string dbPath = FileAccessHelper.GetLocalFilePath("contacts.db3");
            LoadApplication(new App(dbPath));
        }
    }
}