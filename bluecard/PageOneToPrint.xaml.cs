using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace bluecard
{
    /// <summary>
    /// Page content to send to the printer
    /// </summary>
    public sealed partial class PageOneToPrint : Page
    {
        public PageOneToPrint(string ScoutName)
        {
            this.InitializeComponent();
            TextBlock tb1 = (TextBlock)FindName("ScoutName_1_3");
            tb1.Text = ScoutName;
        }
    }
}
