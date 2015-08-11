namespace Gep13.WindowsPhoneSample.Core.Repository
{
    using System;
    using System.Threading.Tasks;
    using Gep13.WindowsPhoneSample.Core.Model;
    using SQLite.Net;
    using SQLite.Net.Platform.WindowsPhone8;
    using Windows.Storage;

    public class Gep13DataContext
    {
        private SQLiteConnection databaseConnection;

        public Gep13DataContext()
        {
        }

        public void OnCreate(string databaseFilePath)
        {
            try
            {
                if (!this.CheckFileExists(databaseFilePath).Result)
                {
                    using (this.databaseConnection = new SQLiteConnection(new SQLitePlatformWP8(), databaseFilePath))
                    {
                        this.databaseConnection.CreateTable<Job>();
                    }
                }
            }
            catch (Exception ex)
            {
                // Should really log this somewhere...
            }
        }

        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);

                if (store != null)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}