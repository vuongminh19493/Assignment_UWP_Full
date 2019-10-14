using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Data.Json;
using Windows.Devices.Midi;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Assignment_UWP_Full.Entity;
using Assignment_UWP_Full.Service;
using Newtonsoft.Json;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment_UWP_Full.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SongForm : Page
    {
        public SongForm()
        {
            this.InitializeComponent();
        }
        private async void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file 
                Thumbnail.Text = file.Path;

                // Open a stream for the selected file. 
                // The 'using' block ensures the stream is disposed 
                // after the image is loaded. 
                using (Windows.Storage.Streams.IRandomAccessStream fileStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    // Set the image source to the selected bitmap. 
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(fileStream);
                    uploadedImage.Source = bitmapImage;
                }
            }
        }
        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            ResetMessage();

            Song song = new Song()
            {
                name = this.Name.Text,
                description = this.Description.Text,
                singer = this.Singer.Text,
                author = this.Author.Text,
                thumbnail = this.Thumbnail.Text,
                link = this.Link.Text,
            };
            Dictionary<string, string> errors = Validate.ValidateSong(song);
            if (errors.Count >0)
            {
                if (errors.ContainsKey("Name"))
                {
                    NameMessage.Text = errors["Name"];
                    NameMessage.Visibility = Visibility.Visible;
                }
                if (errors.ContainsKey("Description"))
                {
                    DescriptionMessage.Text = errors["Description"];
                    DescriptionMessage.Visibility = Visibility.Visible;
                }
                if (errors.ContainsKey("Singer"))
                {
                    SingerMessage.Text = errors["Singer"];
                    SingerMessage.Visibility = Visibility.Visible;
                }
                if (errors.ContainsKey("Author"))
                {
                    AuthorMessage.Text = errors["Name"];
                    AuthorMessage.Visibility = Visibility.Visible;
                }
                if (errors.ContainsKey("Thumbnail"))
                {
                    ThumbnailMessage.Text = errors["Thumbnail"];
                    ThumbnailMessage.Visibility = Visibility.Visible;
                }
                if (errors.ContainsKey("Link"))
                {
                    LinkMessage.Text = errors["Link"];
                    LinkMessage.Visibility = Visibility.Visible;
                }
                return;
            }

            SongService songService = new SongService();
            songService.PostSong(song);
            GoToListSong(null,null);
        }
        private void GoToListSong(object sender, RoutedEventArgs e)
        {
            Home home = FindParent<Home>(this);
            if (home != null)
            {
                home.TheContentFrame.Navigate(typeof(ListSong));
            }
        }

        public static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null) return null;

            var parentT = parent as T;
            return parentT ?? FindParent<T>(parent);
        }
        private void ResetMessage()
        {
            NameMessage.Visibility = Visibility.Collapsed;
            DescriptionMessage.Visibility = Visibility.Collapsed;
            SingerMessage.Visibility = Visibility.Collapsed;
            AuthorMessage.Visibility = Visibility.Collapsed;
            ThumbnailMessage.Visibility = Visibility.Collapsed;
            LinkMessage.Visibility = Visibility.Collapsed;
        }
    }
}
   