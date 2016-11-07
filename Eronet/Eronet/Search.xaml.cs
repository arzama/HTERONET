using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Eronet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Search : Page
    {
        List<mobAppModelAppInfo> l = new List<mobAppModelAppInfo>();
        public Search()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataUtility d = new DataUtility();
            l = d.GetAllApps();

            searchBox.Text = "";
            ListaTrazi.ItemsSource = d.GetAllApps();
        }

        private void searchBox_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Focus(Windows.UI.Xaml.FocusState.Programmatic);  
        }

        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataUtility d = new DataUtility();

            List<mobAppModelAppInfo> temp = new List<mobAppModelAppInfo>();

            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].appHeadline.ToLower().Contains(searchBox.Text.ToLower()))
                    temp.Add(l[i]);
            }

            if(searchBox.Text == "")
                ListaTrazi.ItemsSource = l;
            else
                ListaTrazi.ItemsSource = temp;
        }

        private void ListaTrazi_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AppDetails), (ListaTrazi.SelectedItem as mobAppModelAppInfo).id);
        }
    }
}