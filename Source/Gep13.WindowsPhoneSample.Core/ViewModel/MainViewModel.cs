namespace Gep13.WindowsPhoneSample.Core.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using AutoMapper;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Messaging;

    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Services;

    public class MainViewModel : ViewModelBase
    {
        private readonly IJobService jobService;
        private readonly IBackgroundTaskService backgroundTaskService;

        public MainViewModel(IJobService jobService, IBackgroundTaskService backgroundTaskService)
        {
            this.jobService = jobService;
            this.backgroundTaskService = backgroundTaskService;

            if (this.IsInDesignMode)
            {
                this.Jobs = this.jobService.GetListOfJobs();
            }
        }

        public RelayCommand PageLoadedCommand
        {
            get
            {
                return new RelayCommand(async () => await this.PageLoaded());
            }
        }

        public RelayCommand AddJobCommand
        {
            get
            {
                return new RelayCommand(this.AddJob);
            }
        }

        public ObservableCollection<JobViewModel> Jobs { get; set; }

        private async Task PageLoaded()
        {
            Messenger.Default.Register<NotificationMessage>(
                this,
                m =>
                    {
                        if (m.Notification.Equals(Constants.Messages.SystemEventBackgroundTaskCompleted))
                        {
                            this.FetchJobs();
                        }
                    });

            await this.backgroundTaskService.ActivateService();
            this.FetchJobs();
        }

        private void FetchJobs()
        {
            this.Jobs = this.jobService.GetListOfJobs();
        }

        private void AddJob()
        {
            var job = new JobDto
            {
                ClientName = "Test",
                CustomerJobNo = "1234",
                JobStatus = "ALLOCATED",
                JourneyId = 1
            };

            var newJob = this.jobService.AddJob(job);

            this.Jobs.Add(Mapper.Map<JobViewModel>(newJob));
        }
    }
}