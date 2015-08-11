namespace Gep13.WindowsPhoneSample.Core.Fakes.Services
{
    using System.Collections.ObjectModel;

    using AutoMapper;

    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Model;
    using Gep13.WindowsPhoneSample.Core.Repository;
    using Gep13.WindowsPhoneSample.Core.Services;
    using Gep13.WindowsPhoneSample.Core.ViewModel;

    public class FakeJobService : IJobService
    {
        private readonly IJobRepository jobRepository;

        public FakeJobService(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public ObservableCollection<JobViewModel> GetListOfJobs()
        {
            var jobs = this.jobRepository.GetJobsByJourneyId(1);
            return Mapper.Map<ObservableCollection<JobViewModel>>(jobs);
        }

        public JobViewModel AddJob(JobDto job)
        {
            return Mapper.Map<JobViewModel>(this.jobRepository.AddJob(Mapper.Map<Job>(job)));
        }
    }
}