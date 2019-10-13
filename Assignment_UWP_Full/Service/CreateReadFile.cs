using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_UWP_Full.Entity;

namespace Assignment_UWP_Full.Service
{
    class CreateReadFile
    {
        public void SaveTokenToLocalStorage(string token)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder
                .CreateFileAsync("nekot.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter()
                .GetResult();
            Windows.Storage.FileIO.WriteTextAsync(sampleFile, token).GetAwaiter().GetResult();
        }
        public string GetToken()
        {
            Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder.GetFileAsync("nekot.txt").GetAwaiter().GetResult();
           string token = Windows.Storage.FileIO.ReadTextAsync(sampleFile).GetAwaiter().GetResult();
            return token;
        }

    }
}
