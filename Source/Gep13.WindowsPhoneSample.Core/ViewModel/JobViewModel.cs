namespace Gep13.WindowsPhoneSample.Core.ViewModel
{
    using GalaSoft.MvvmLight;

    public class JobViewModel : ViewModelBase
    {
        public int Id { get; set; }

        public int JourneyId { get; set; }

        public string JobStatus { get; set; }

        public string CustomerJobNo { get; set; }

        public string ClientName { get; set; }
    }
}