using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using expensessApp.Droid.Dependencies;
using expensessApp.Interfaces;
using Java.IO;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace expensessApp.Droid.Dependencies
{
    class Share : IShare
    {
        public Task Show(string title, string message, string filePath)
        {
            var intent = new Intent(Intent.ActionSend);
            var documentUri = FileProvider.GetUriForFile(CrossCurrentActivity.Current.AppContext, "com.companyname.expensessapp.fileprovider", new Java.IO.File(filePath));
            intent.PutExtra(Intent.ExtraStream, documentUri);
            intent.PutExtra(Intent.ExtraText, title);
            intent.PutExtra(Intent.ExtraSubject, message);

            var chooserIntent = Intent.CreateChooser(intent, title);
            chooserIntent.SetFlags(ActivityFlags.GrantReadUriPermission);
            Android.App.Application.Context.StartActivity(chooserIntent);
            return Task.FromResult(true);
        }
    }
}