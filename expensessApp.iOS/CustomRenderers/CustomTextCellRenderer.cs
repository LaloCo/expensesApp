using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using expensessApp.iOS.CustomRenderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer)) ]
namespace expensessApp.iOS.CustomRenderers
{
    public class CustomTextCellRenderer : TextCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            return base.GetCell(item, reusableCell, tv);
        }
    }
}