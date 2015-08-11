namespace Gep13.WindowsPhoneSample.Core.Repository
{
    using System.Collections.ObjectModel;
    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Model;

    public interface IJobRepository
    {
        ReadOnlyCollection<JobDto> GetJobsByJourneyId(int journeyId);

        JobDto AddJob(Job job);

        JobDto UpdateJobStatus(int jobId, string status);

        int DeleteAllJobs();
    }
}