namespace Gep13.WindowsPhoneSample.Core.Repository
{
    using System.IO;
    using Windows.Storage;

    public class BaseRepository
    {
        public BaseRepository()
        {
            this.DatabaseFilePath = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "gep13.sqlite"));
        }

        public string DatabaseFilePath { get; set; }
    }
}