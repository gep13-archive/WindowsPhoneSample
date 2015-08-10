namespace Gep13.WindowsPhoneSample.Core.Services
{
    using System.Collections.ObjectModel;

    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.WindowsPhone.ViewModel;

    public interface IJobService
    {
        ObservableCollection<JobViewModel> GetListOfJobs();

        JobViewModel AddJob(JobDto job);
    }
}