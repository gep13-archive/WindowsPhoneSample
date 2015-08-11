namespace Gep13.WindowsPhoneSample.Core.Fakes.Repository
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using AutoMapper;
    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Model;
    using Gep13.WindowsPhoneSample.Core.Repository;

    public class FakeJobRepository : IJobRepository
    {
        private readonly List<Job> jobs = new List<Job>();

        public FakeJobRepository()
        {
            this.jobs.Add(new Job { CustomerJobNo = "1234", ClientName = "Client1", Id = 1, JobStatus = "ALLOCATED", JourneyId = 1 });
            this.jobs.Add(new Job { CustomerJobNo = "5678", ClientName = "Client2", Id = 2, JobStatus = "ACCEPTED", JourneyId = 1 });
        }

        public ReadOnlyCollection<JobDto> GetJobsByJourneyId(int journeyId)
        {
            return Mapper.Map<ReadOnlyCollection<JobDto>>(this.jobs);
        }

        public JobDto AddJob(Job job)
        {
            this.jobs.Add(job);
            return Mapper.Map<JobDto>(job);
        }

        public JobDto UpdateJobStatus(int jobId, string status)
        {
            var job = this.jobs.FirstOrDefault(j => j.Id == jobId);

            if (job != null)
            {
                job.JobStatus = status;
            }

            return Mapper.Map<JobDto>(job);
        }

        public int DeleteAllJobs()
        {
            var jobCount = this.jobs.Count;
            this.jobs.Clear();
            return jobCount;
        }
    }
}