using System;
using System.IO;
using GasAgency.Droid;
using GasAgency.Helpers;
using Xamarin.Forms;

[assembly:Dependency(typeof(LocalDatabaseHelper))]
namespace GasAgency.Droid
{
    public class LocalDatabaseHelper: ILocalDatabaseHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}