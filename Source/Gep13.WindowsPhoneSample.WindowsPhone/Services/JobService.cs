namespace Gep13.WindowsPhoneSample.Core.Services
{
    using System.Collections.ObjectModel;
    using AutoMapper;
    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Model;
    using Gep13.WindowsPhoneSample.Core.Repository;
    using Gep13.WindowsPhoneSample.WindowsPhone.ViewModel;

    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public ObservableCollection<JobViewModel> GetListOfJobs()
        {
            var jobs = this.jobRepository.GetJobsByJourneyId("1");

            return new ObservableCollection<JobViewModel>(Mapper.Map<ObservableCollection<JobViewModel>>(jobs));
        }

        public JobViewModel AddJob(JobDto job)
        {
            return Mapper.Map<JobViewModel>(this.jobRepository.AddJob(Mapper.Map<Job>(job)));
        }
    }
}