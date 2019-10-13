using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_UWP_Full.Entity;

namespace Assignment_UWP_Full.Service
{
    interface ISongService
    {
        Song PostSong(Song song);

        ObservableCollection<Song> GetSongs();
        ObservableCollection<Song> GetMySongs();
    }
}
