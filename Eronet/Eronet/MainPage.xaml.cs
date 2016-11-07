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
using System.Net.Http;
using Windows.UI.Popups;
using System.Xml.Serialization;
using System.Threading.Tasks;
//--------------------------------------------------------//

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Eronet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            //---------------------------------------------------------//
            //---------------------------------------------------------//
            // Show loading animation while the data downloads
            progress.IsActive = true;
            progress.Visibility = Visibility.Visible;

            // Check if there is internet connection
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                throw new Exception("No internet connection available...");
            else
            {
                //Calling a method that will create instance of DataUtility class 
                //which will download and parse xml data
                LoadData();
            }
            //---------------------------------------------------------//
            //---------------------------------------------------------//
        }

        //---------------------------------------------------------//
        //---     POPUP MESSAGE DIALOG IF THERE ARE ERRORS      ---//
        //---------------------------------------------------------//
        private async void ShowPopUp(string s)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(s);

            // Add commands and set their callbacks
            messageDialog.Commands.Add(new UICommand(
                "OK", new UICommandInvokedHandler(this.CommandInvokedHandler)));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 0;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }
        //---------------------------------------------------------//
        private void CommandInvokedHandler(IUICommand command)
        {
            Application.Current.Exit();
        }
        //--------------------------------------------------------//

        //---------------------------------------------------------//
        //---              DOWNLOADS THE XML DATA               ---//
        //---------------------------------------------------------//
        private async void LoadData()
        {
            try
            {
                DataUtility preporucene = new DataUtility();

                await preporucene.GetData();

                //Set ListView.ItemsSource and enable it
                ListaPreporucenih.ItemsSource = preporucene.GetPreporuceneApps();
                ListaPreporucenih.IsEnabled = true;

                // Hide loading animation
                progress.IsActive = false;
                progress.Visibility = Visibility.Collapsed;

                LoadNajgledanije();
                GetKategorije();
            }
            catch (Exception e)
            {
                // Call function to show pop-up message to the user about the error
                ShowPopUp(e.Message);
            }
        }
        //---------------------------------------------------------//

        //---------------------------------------------------------//
        //---              LOAD NAJGLEDANIJE APPS               ---//
        //---------------------------------------------------------//
        private void LoadNajgledanije()
        {
            DataUtility najgledanije = new DataUtility();

            ListaNajgledaniji.ItemsSource = najgledanije.GetNajgledanije();
        }
        //---------------------------------------------------------//

        //---------------------------------------------------------//
        //---                   GET KATEGORIJE                  ---//
        //---------------------------------------------------------//
        private void GetKategorije()
        {
            DataUtility kat = new DataUtility();

            ListaKategorija.ItemsSource = kat.GetKategorije();
        }
        //---------------------------------------------------------//

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.
            
            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void ListaPreporucenih_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AppDetails), (ListaPreporucenih.SelectedItem as mobAppModelAppInfo).id);
        }

        private void ListaNajgledaniji_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AppDetails), (ListaNajgledaniji.SelectedItem as mobAppModelAppInfo).id);
        }

        private void ListaKategorija_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Category), (ListaKategorija.SelectedItem as string));
        }

        private void sBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Search));
        }
    }
}