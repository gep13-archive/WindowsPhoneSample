namespace Gep13.WindowsPhoneSample.Core.Services
{
    using System.Collections.ObjectModel;
    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.ViewModel;

    /// <summary>
    /// The JobService interface.
    /// </summary>
    public interface IJobService
    {
        /// <summary>
        /// The get list of jobs.
        /// </summary>
        /// <returns>
        /// The <see cref="ObservableCollection"/>.
        /// </returns>
        ObservableCollection<JobViewModel> GetListOfJobs();

        /// <summary>
        /// The add job.
        /// </summary>
        /// <param name="job">
        /// The job.
        /// </param>
        /// <returns>
        /// The <see cref="JobViewModel"/>.
        /// </returns>
        JobViewModel AddJob(JobDto job);
    }
}