namespace Gep13.WindowsPhoneSample.Core.Model
{
    using SQLite.Net.Attributes;

    public class Job
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int JourneyId { get; set; }

        public string JobStatus { get; set; }

        public string CustomerJobNo { get; set; }

        public string ClientName { get; set; }
    }
}