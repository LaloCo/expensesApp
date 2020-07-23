using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using expensessApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ResolutionGroupName("Bommijn")]
[assembly:ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace expensessApp.Droid.Effects
{
    class SelectedEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            
        }

        protected override void OnDetached()
        {
        }
    }
}