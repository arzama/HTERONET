using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//--------------------------------------------------------//
using Windows.Phone.UI.Input;
//--------------------------------------------------------//

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Eronet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Category : Page
    {
        public Category()
        {
            this.InitializeComponent();
            
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             string s = (string)e.Parameter;
            
            DataUtility d = new DataUtility();
            List<mobAppModelAppInfo> a = d.GetAppsPoKategoriji(s);

            ListaPoKategoriji.ItemsSource = a;

            pagetitle.Text = s;
        }

        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        private void ListaPoKategoriji_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AppDetails), (ListaPoKategoriji.SelectedItem as mobAppModelAppInfo).id);
        }

        private void sBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Search));
        }
    }
}
