using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Provider;
using Assignment_UWP_Full.Entity;
using Assignment_UWP_Full.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assignment_UWP_Full.Service
{
    class SongService : ISongService
    {
        private ISongService _songServiceImplementation;

        public Song PostSong(Song song)
        {
            string token = null;
            HttpContent content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            CreateReadFile createReadFile = new CreateReadFile();
            token = createReadFile.GetToken();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var response = httpClient.PostAsync(ApiUrl.POST_SONG_URL, content).Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine(response);
            return song;
        }

        ObservableCollection<Song> ISongService.GetSongs()
        {
            return _songServiceImplementation.GetSongs();
        }

        public static ObservableCollection<Song> GetSongs()
        {
            string token = null;
                ObservableCollection<Song> songs = new ObservableCollection<Song>();
                CreateReadFile createReadFile = new CreateReadFile();
                token = createReadFile.GetToken();
                // thực hiện request lên api lấy token về.
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
                var responseContent = client.GetAsync(ApiUrl.GET_SONG_URL).Result.Content.ReadAsStringAsync().Result;
                songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(responseContent);
                return songs;
        }
        ObservableCollection<Song> ISongService.GetMySongs()
        {
            return _songServiceImplementation.GetMySongs();
        }
        public static ObservableCollection<Song> GetMySongs()
        {
            string token = null;
            ObservableCollection<Song> songs = new ObservableCollection<Song>();
            CreateReadFile createReadFile = new CreateReadFile();
            token = createReadFile.GetToken();
            // thực hiện request lên api lấy token về.
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var responseContent = client.GetAsync(ApiUrl.MY_SONG_URL).Result.Content.ReadAsStringAsync().Result;
            songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(responseContent);
            return songs;
        }

    }
}
