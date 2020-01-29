using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Printing;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409



namespace bluecard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;

        public int sideShown = 1;
        public int print_Page = 1;
        public string ScoutName = "Joe Scout";
        public string MeritBadge = "Citizenship in the Community";

        private PrintHelper printHelper;

        ObservableCollection<string> meritBadges = new ObservableCollection<string>();

        public MainPage()
        {
            meritBadges.Add("");
            meritBadges.Add("American Business");
            meritBadges.Add("American Cultures");
            meritBadges.Add("American Heritage");
            meritBadges.Add("American Labor");
            meritBadges.Add("Animal Science");
            meritBadges.Add("Animation");
            meritBadges.Add("Archeology");
            meritBadges.Add("Archery");
            meritBadges.Add("Architecture");
            meritBadges.Add("Art");
            meritBadges.Add("Astronomy");
            meritBadges.Add("Athletics");
            meritBadges.Add("Automotive Maintenance");
            meritBadges.Add("Aviation");
            meritBadges.Add("Backpacking");
            meritBadges.Add("Basketry");
            meritBadges.Add("Bird Study");
            meritBadges.Add("Bugling");
            meritBadges.Add("Camping");
            meritBadges.Add("Canoeing");
            meritBadges.Add("Chemistry");
            meritBadges.Add("Chess");
            meritBadges.Add("Citizenship in the Community");
            meritBadges.Add("Citizenship in the Nation");
            meritBadges.Add("Citizenship in the World");
            meritBadges.Add("Climbing");
            meritBadges.Add("Coin Collecting");
            meritBadges.Add("Collections");
            meritBadges.Add("Communication");
            meritBadges.Add("Composite Materials");
            meritBadges.Add("Cooking");
            meritBadges.Add("Crime Prevention");
            meritBadges.Add("Cycling");
            meritBadges.Add("Dentistry");
            meritBadges.Add("Digital Technology");
            meritBadges.Add("Disabilities Awareness");
            meritBadges.Add("Dog Care");
            meritBadges.Add("Drafting");
            meritBadges.Add("Electricity");
            meritBadges.Add("Electronics");
            meritBadges.Add("Emergency Preparedness");
            meritBadges.Add("Energy");
            meritBadges.Add("Engineering");
            meritBadges.Add("Entrepreneurship");
            meritBadges.Add("Environmental Science");
            meritBadges.Add("Exploration");

            meritBadges.Add("Landscape Architecture");
            meritBadges.Add("Law");
            meritBadges.Add("Leatherwork");
            meritBadges.Add("Lifesaving");
            meritBadges.Add("Mammal Study");

            meritBadges.Add("Personal Fitness");
            meritBadges.Add("Personal Management");

            meritBadges.Add("Rowing");

            meritBadges.Add("Wood Carving");
            meritBadges.Add("Woodwork");

            this.InitializeComponent();

            // This is a static public property that allows downstream pages to get a handle to the MainPage instance
            // in order to call methods that are in this class.
            Current = this;
            //SampleTitle.Text = FEATURE_NAME;

        }

        public string GetScoutName()
        {
            return ScoutName;
        }

        /// <summary>
        /// Display a message to the user.
        /// This method may be called from any thread.
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="type"></param>
        public void NotifyUser(string strMessage, NotifyType type)
        {
            // If called from the UI thread, then update immediately.
            // Otherwise, schedule a task on the UI thread to perform the update.
            if (Dispatcher.HasThreadAccess)
            {
                UpdateStatus(strMessage, type);
            }
            else
            {
                var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => UpdateStatus(strMessage, type));
            }
        }

        private void UpdateStatus(string strMessage, NotifyType type)
        {
            switch (type)
            {
                case NotifyType.StatusMessage:
                    //StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    break;
                case NotifyType.ErrorMessage:
                    //StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;
            }

            //StatusBlock.Text = strMessage;

            // Collapse the StatusBlock if it has no text to conserve real estate.
            //StatusBorder.Visibility = (StatusBlock.Text != String.Empty) ? Visibility.Visible : Visibility.Collapsed;
            //if (StatusBlock.Text != String.Empty)
            //{
            //    StatusBorder.Visibility = Visibility.Visible;
            //    StatusPanel.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    StatusBorder.Visibility = Visibility.Collapsed;
            //    StatusPanel.Visibility = Visibility.Collapsed;
            //}

            // Raise an event if necessary to enable a screen reader to announce the status update.
            //var peer = FrameworkElementAutomationPeer.FromElement(StatusBlock);
            //if (peer != null)
            //{
            //    peer.RaiseAutomationEvent(AutomationEvents.LiveRegionChanged);
            //}
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
                Image img = sender as Image;
                if (img != null)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.UriSource = new Uri("ms-appx:///Assets/34124.jpg");
                    img.Source = bitmapImage;
            }
        }

        private void Sig_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = sender as Image;
            if (img != null)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.UriSource = new Uri("ms-appx:///Assets/signature.png");
                img.Source = bitmapImage;
            }
        }

        private void Menu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private void ScoutName_Select(object sender, RoutedEventArgs e)
        {
            if (sideShown == 1)
            {
                TextBlock tb1 = (TextBlock)FindName("ScoutName_1_3");
                tb1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                TextBox tbx1 = (TextBox)FindName("ScoutName_Box");
                tbx1.Text = ScoutName;
                tbx1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        private void ScoutName_Changed(object sender, RoutedEventArgs e)
        {
            TextBox tbx1 = sender as TextBox;
            ScoutName = tbx1.Text;
            TextBlock tb1 = (TextBlock)FindName("ScoutName_1_3");
            tb1.Text = ScoutName;
            TextBlock tb2 = (TextBlock)FindName("ScoutName_2_2");
            tb2.Text = ScoutName;
            TextBlock tb3 = (TextBlock)FindName("ScoutName_2_3");
            tb3.Text = ScoutName;
        }

        private void ScoutName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbx1 = sender as TextBox;
            tbx1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb1 = (TextBlock)FindName("ScoutName_1_3");
            tb1.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void MB_Select(object sender, RoutedEventArgs e)
        {
            if (sideShown == 2)
            {
                TextBlock tb1 = (TextBlock)FindName("MB_2_1");
                tb1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ComboBox cbx1 = (ComboBox)FindName("MBSelect");
                cbx1.SelectedIndex = 3;
                cbx1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        //private void MBSelect_DropdownClosed(object sender, EventArgs e)
        //{
        //    ComboBox cbx1 = sender as ComboBox;
        //    cbx1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        //    TextBlock tb1 = (TextBlock)FindName("MB_2_1");
        //    tb1.Visibility = Windows.UI.Xaml.Visibility.Visible;
        //}

        private void MBSelect_Selection(object sender, RoutedEventArgs e)
        {
            ComboBox cbx1 = sender as ComboBox;
            MeritBadge = (string)cbx1.SelectedValue;
            TextBlock tb1 = (TextBlock)FindName("MB_2_1");
            tb1.Text = MeritBadge;
            TextBlock tb2 = (TextBlock)FindName("MB_2_2");
            tb2.Text = MeritBadge;
            TextBlock tb3 = (TextBlock)FindName("MB_2_3");
            tb3.Text = MeritBadge;
        }

        private void ShowSide1_Select(object sender, RoutedEventArgs e)
        {
            sideShown = 1;
            ToggleMenuFlyoutItem it1 = sender as ToggleMenuFlyoutItem;
            it1.IsChecked = true;
            ToggleMenuFlyoutItem it2 = (ToggleMenuFlyoutItem)FindName("Side2Display");
            it2.IsChecked = false;
            Image img = (Image)FindName("MainImage");
            // user wants to see card side 1
            if (img != null)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.UriSource = new Uri("ms-appx:///Assets/34124.jpg");
                img.Source = bitmapImage;
            }
            TextBlock tb1 = (TextBlock)FindName("ScoutName_1_3");
            tb1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb2 = (TextBlock)FindName("Check_1_3");
            tb2.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb3 = (TextBlock)FindName("UnitType_1_3");
            tb3.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb4 = (TextBlock)FindName("UnitNo_1_3");
            tb4.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb5 = (TextBlock)FindName("District_1_3");
            tb5.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb6 = (TextBlock)FindName("Council_1_3");
            tb6.Visibility = Windows.UI.Xaml.Visibility.Visible;
            Image im1 = (Image)FindName("SigImage");
            im1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb7 = (TextBlock)FindName("MB_2_1");
            tb7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb8 = (TextBlock)FindName("ScoutName_2_2");
            tb8.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb9 = (TextBlock)FindName("MB_2_2");
            tb9.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb10 = (TextBlock)FindName("ScoutName_2_3");
            tb10.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb11 = (TextBlock)FindName("Check_2_3");
            tb11.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb12 = (TextBlock)FindName("UnitNo_2_3");
            tb12.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb13 = (TextBlock)FindName("MB_2_3");
            tb13.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void ShowSide2_Select(object sender, RoutedEventArgs e)
        {
            // user wants to see card side 2
            sideShown = 2;
            ToggleMenuFlyoutItem it2 = sender as ToggleMenuFlyoutItem;
            it2.IsChecked = true;
            ToggleMenuFlyoutItem it1 = (ToggleMenuFlyoutItem)FindName("Side1Display");
            it1.IsChecked = false;
            Image img = (Image)FindName("MainImage");
            if (img != null)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.UriSource = new Uri("ms-appx:///Assets/34124_2.jpg");
                img.Source = bitmapImage;
            }
            TextBlock tb1 = (TextBlock)FindName("ScoutName_1_3");
            tb1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb2 = (TextBlock)FindName("Check_1_3");
            tb2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb3 = (TextBlock)FindName("UnitType_1_3");
            tb3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb4 = (TextBlock)FindName("UnitNo_1_3");
            tb4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb5 = (TextBlock)FindName("District_1_3");
            tb5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb6 = (TextBlock)FindName("Council_1_3");
            tb6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            Image im1 = (Image)FindName("SigImage");
            im1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            TextBlock tb7 = (TextBlock)FindName("MB_2_1");
            tb7.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb8 = (TextBlock)FindName("ScoutName_2_2");
            tb8.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb9 = (TextBlock)FindName("MB_2_2");
            tb9.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb10 = (TextBlock)FindName("ScoutName_2_3");
            tb10.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb11 = (TextBlock)FindName("Check_2_3");
            tb11.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb12 = (TextBlock)FindName("UnitNo_2_3");
            tb12.Visibility = Windows.UI.Xaml.Visibility.Visible;
            TextBlock tb13 = (TextBlock)FindName("MB_2_3");
            tb13.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Initialize common helper class and register for printing
            printHelper = new PrintHelper(this);
            printHelper.RegisterForPrinting();
            PrintManager printMan = PrintManager.GetForCurrentView();
            //printMan.PrintTaskRequested += PrintTaskRequested;

            // Initialize print content for this scenario
            //printHelper.PreparePrintContent(new PageToPrint());

            // Tell the user how to print
            //MainPage.Current.NotifyUser("Print contract registered with customization, use the Print button to print.", NotifyType.StatusMessage);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (printHelper != null)
            {
                printHelper.UnregisterForPrinting();
            }
        }

        async private void OnPrintFrontClick(object sender, RoutedEventArgs e)
        {
            if (Windows.Graphics.Printing.PrintManager.IsSupported())
            {
                try
                {
                    // Initialize print content for this scenario
                    //printHelper.PreparePrintContent();
                    
                    printHelper.ScoutName = ScoutName;
                    printHelper.MeritBadge = MeritBadge;

                    print_Page = 1;
                    printHelper.print_Page = print_Page;
                    
                    // Show print UI
                    await Windows.Graphics.Printing.PrintManager.ShowPrintUIAsync();
                }
                catch
                {
                    // Printing cannot proceed at this time
                    ContentDialog noPrintingDialog = new ContentDialog()
                    {
                        Title = "Printing error",
                        Content = "\nSorry, printing can' t proceed at this time.",
                        PrimaryButtonText = "OK"
                    };
                    await noPrintingDialog.ShowAsync();
                }
            }
            else
            {
                // Printing is not supported on this device
                ContentDialog noPrintingDialog = new ContentDialog()
                {
                    Title = "Printing not supported",
                    Content = "\nSorry, printing is not supported on this device.",
                    PrimaryButtonText = "OK"
                };
                await noPrintingDialog.ShowAsync();
            }
        }

        async private void OnPrintBackClick(object sender, RoutedEventArgs e)
        {
            if (Windows.Graphics.Printing.PrintManager.IsSupported())
            {
                try
                {
                // Initialize print content for this scenario
                //printHelper.PreparePrintContent();

                printHelper.ScoutName = ScoutName;
                printHelper.MeritBadge = MeritBadge;

                print_Page = 2;
                printHelper.print_Page = print_Page;

                // Show print UI
                await Windows.Graphics.Printing.PrintManager.ShowPrintUIAsync();
                }
                catch
                {
                    // Printing cannot proceed at this time
                    ContentDialog noPrintingDialog = new ContentDialog()
                    {
                        Title = "Printing error",
                        Content = "\nSorry, printing can' t proceed at this time.",
                        PrimaryButtonText = "OK"
                    };
                    await noPrintingDialog.ShowAsync();
                }
            }
            else
            {
                // Printing is not supported on this device
                ContentDialog noPrintingDialog = new ContentDialog()
                {
                    Title = "Printing not supported",
                    Content = "\nSorry, printing is not supported on this device.",
                    PrimaryButtonText = "OK"
                };
                await noPrintingDialog.ShowAsync();
            }
        }
    }

    public enum NotifyType
    {
        StatusMessage,
        ErrorMessage
    };
}
