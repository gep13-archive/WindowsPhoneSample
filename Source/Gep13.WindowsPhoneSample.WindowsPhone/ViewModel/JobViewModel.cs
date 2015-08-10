namespace Gep13.WindowsPhoneSample.WindowsPhone.ViewModel
{
    using GalaSoft.MvvmLight;

    public class JobViewModel : ViewModelBase
    {
        public string JobId { get; set; }

        public string JourneyId { get; set; }

        public string JobStatus { get; set; }

        public string JobStatusLabel { get; set; }

        public string CustomerJobNo { get; set; }

        public string ClientName { get; set; }
    }
}