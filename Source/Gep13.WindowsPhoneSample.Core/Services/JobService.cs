namespace Gep13.WindowsPhoneSample.Core.Services
{
    using System.Collections.ObjectModel;
    using AutoMapper;
    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Model;
    using Gep13.WindowsPhoneSample.Core.Repository;
    using Gep13.WindowsPhoneSample.Core.ViewModel;

    /// <summary>
    /// The job service.
    /// </summary>
    public class JobService : IJobService
    {
        /// <summary>
        /// The job repository.
        /// </summary>
        private readonly IJobRepository jobRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobService"/> class.
        /// </summary>
        /// <param name="jobRepository">
        /// The job repository.
        /// </param>
        public JobService(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        /// <summary>
        /// The get list of jobs.
        /// </summary>
        /// <returns>
        /// The <see cref="ObservableCollection"/>.
        /// </returns>
        public ObservableCollection<JobViewModel> GetListOfJobs()
        {
            var jobs = this.jobRepository.GetJobsByJourneyId(1);

            return new ObservableCollection<JobViewModel>(Mapper.Map<ObservableCollection<JobViewModel>>(jobs));
        }

        /// <summary>
        /// The add job.
        /// </summary>
        /// <param name="job">
        /// The job.
        /// </param>
        /// <returns>
        /// The <see cref="JobViewModel"/>.
        /// </returns>
        public JobViewModel AddJob(JobDto job)
        {
            var newJob = this.jobRepository.AddJob(Mapper.Map<Job>(job));
            return Mapper.Map<JobViewModel>(newJob);
        }
    }
}