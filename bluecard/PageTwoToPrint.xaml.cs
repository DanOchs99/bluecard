using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace bluecard
{
    /// <summary>
    /// Page content to send to the printer
    /// </summary>
    public sealed partial class PageTwoToPrint : Page
    {
        public PageTwoToPrint(string ScoutName, string MeritBadge)
        {
            this.InitializeComponent();
            TextBlock tb1 = (TextBlock)FindName("ScoutName_2_2");
            tb1.Text = ScoutName;
            TextBlock tb2 = (TextBlock)FindName("ScoutName_2_3");
            tb2.Text = ScoutName;
            TextBlock tb3 = (TextBlock)FindName("MB_2_1");
            tb3.Text = MeritBadge;
            TextBlock tb4 = (TextBlock)FindName("MB_2_2");
            tb4.Text = MeritBadge;
            TextBlock tb5 = (TextBlock)FindName("MB_2_3");
            tb5.Text = MeritBadge;
        }
    }
}
