namespace Gep13.WindowsPhoneSample.Core.Repository
{
    using System.Collections.ObjectModel;
    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Model;

    public interface IJobRepository
    {
        ReadOnlyCollection<JobDto> GetJobsByJourneyId(string journeyId);

        JobDto AddJob(Job job);

        JobDto UpdateJobStatus(string jobId, string status, string statusLabel);

        int DeleteAllJobs();
    }
}