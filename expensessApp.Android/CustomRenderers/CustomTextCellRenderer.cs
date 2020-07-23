using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using expensessApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomTextCellRenderer))]
namespace expensessApp.Droid.CustomRenderers
{
    public class CustomTextCellRenderer : ViewCellRenderer
    {

        private Android.Views.View _cell;
        private bool _isSelected;
        private Drawable _defaultBackground;
        


        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);
            _isSelected = false;
            _defaultBackground = _cell.Background;
            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            if (e.PropertyName.Equals("IsSelected"))
            {
                _isSelected = !_isSelected;

                if (_isSelected)
                {
                    _cell.SetBackgroundColor(Color.FromHex("#E5E5E5").ToAndroid());
                }
                else
                {
                    _cell.Background = _defaultBackground;

                }
            }
        }
    }
}