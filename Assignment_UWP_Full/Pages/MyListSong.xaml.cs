using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Assignment_UWP_Full.Entity;
using Assignment_UWP_Full.Service;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment_UWP_Full.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyListSong : Page
    {
        private ISongService songService;
        private bool _isPlaying = false;
        private int _currentIndex = 0;
        private ObservableCollection<Song> _mySongs;
        public MyListSong()
        {
            this.InitializeComponent();
            songService = new SongService();
            LoadMySongs();

        }

        private void LoadMySongs()
        {
            _mySongs = SongService.GetMySongs();
            ListViewSong.ItemsSource = _mySongs;

        }

       
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            MyMediaPlayer1.Pause();
        }

        private void ListViewSong_OnDoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            var selectItem = ListViewSong.SelectedItem as Song;

            if (selectItem != null)
            {
                _currentIndex = _mySongs.IndexOf(selectItem);
                MyMediaPlayer1.Source = new Uri(selectItem.link);
                Play();
            }
        }

        private void SelectSong(object sender, TappedRoutedEventArgs e)
        {
            var selectItem = sender as StackPanel;
            MyMediaPlayer1.Pause();
            if (selectItem != null)
            {
                if (selectItem.Tag is Song currentSong)
                {
                    _currentIndex = _mySongs.IndexOf(currentSong);
                    MyMediaPlayer1.Source = new Uri(currentSong.link);
                    Play();
                }
            }
        }

        private void Play()
        {
            MyMediaPlayer1.Source = new Uri(_mySongs[_currentIndex].link);
            ControlLabel.Text = "Now Playing " + _mySongs[_currentIndex].name;
            ListViewSong.SelectedIndex = _currentIndex;
            
            MyMediaPlayer1.Play();
            StatusButton.Icon = new SymbolIcon(Symbol.Pause);
            _isPlaying = true;
        }

        private void Pause()
        {
            ControlLabel.Text = "Pause";
            MyMediaPlayer1.Pause();
            StatusButton.Icon = new SymbolIcon(Symbol.Play);
            _isPlaying = false;
        }



       
        private void PreviousButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentIndex--;
            if (_currentIndex < 0)
            {
                _currentIndex = _mySongs.Count - 1;
            }
            else if (_currentIndex >= _mySongs.Count)
            {
                _currentIndex = 0;
            }
            Play();
        }

        private void StatusButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_isPlaying)
            {
                Pause();
            }
            else
            {
                Play();
            }
        }

        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentIndex++;
            if (_currentIndex >= _mySongs.Count || _currentIndex < 0)
            {
                _currentIndex = 0;
            }
            Play();
        }
    }
}