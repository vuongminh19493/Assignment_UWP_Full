using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_UWP_Full
{
    class ApiUrl
    {
        public const string API_BASE_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2";
        public const string REGISTER_URL = API_BASE_URL + "/members";
        public const string LOGIN_URL = API_BASE_URL + "/members/authentication";
        public const string GET_INFORMATION_URL = API_BASE_URL + "/members/information";
        public const string GET_SONG_URL = API_BASE_URL + "/songs";
        public const string POST_SONG_URL = API_BASE_URL + "/songs";
        public const string MY_SONG_URL = API_BASE_URL + "/songs/get-mine";
    }
}
