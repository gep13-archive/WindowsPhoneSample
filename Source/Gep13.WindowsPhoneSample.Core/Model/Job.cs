namespace Gep13.WindowsPhoneSample.Core.Model
{
    using SQLite.Net.Attributes;

    public class Job
    {
        [PrimaryKey]
        public string JobId { get; set; }

        public string JourneyId { get; set; }

        public string JobStatus { get; set; }

        public string JobStatusLabel { get; set; }

        public string CustomerJobNo { get; set; }

        public string ClientName { get; set; }
    }
}