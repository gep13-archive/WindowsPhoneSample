using GalaSoft.MvvmLight;

namespace Gep13.WindowsPhoneSample.WindowsPhone.ViewModel
{
    using System.Collections.ObjectModel;

    using AutoMapper;

    using GalaSoft.MvvmLight.Command;

    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Services;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IJobService jobService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IJobService jobService)
        {
            this.jobService = jobService;

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
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