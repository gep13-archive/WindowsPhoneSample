namespace Gep13.WindowsPhoneSample.Core.ViewModel
{
    using System.Collections.ObjectModel;
    using AutoMapper;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Services;

    public class MainViewModel : ViewModelBase
    {
        private readonly IJobService jobService;

        public MainViewModel(IJobService jobService)
        {
            this.jobService = jobService;
        }

        public RelayCommand PageLoadedCommand
        {
            get
            {
                return new RelayCommand(this.FetchJobs);
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