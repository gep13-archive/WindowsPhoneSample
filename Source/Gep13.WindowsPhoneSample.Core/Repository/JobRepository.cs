namespace Gep13.WindowsPhoneSample.Core.Repository
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using AutoMapper;
    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Model;
    using SQLite.Net;
    using SQLite.Net.Platform.WindowsPhone8;

    public class JobRepository : BaseRepository, IJobRepository
    {
        public ReadOnlyCollection<JobDto> GetJobsByJourneyId(int journeyId)
        {
            using (var databaseConnection = new SQLiteConnection(new SQLitePlatformWP8(), this.DatabaseFilePath))
            {
                var jobs = databaseConnection.Table<Job>().Where(j => j.JourneyId == journeyId).ToList<Job>();
                return new ReadOnlyCollection<JobDto>(Mapper.Map<ObservableCollection<JobDto>>(jobs));
            }
        }

        public JobDto UpdateJobStatus(int jobId, string status)
        {
            using (var databaseConnection = new SQLiteConnection(new SQLitePlatformWP8(), this.DatabaseFilePath))
            {
                var job = databaseConnection.Table<Job>().FirstOrDefault(j => j.Id == jobId);

                if (job == null)
                {
                    throw new Exception("Unable to find Job in database!");
                }

                job.JobStatus = status;
                databaseConnection.Update(job);

                return Mapper.Map<JobDto>(job);
            }
        }

        public JobDto AddJob(Job job)
        {
            using (var databaseConnection = new SQLiteConnection(new SQLitePlatformWP8(), this.DatabaseFilePath))
            {
                databaseConnection.RunInTransaction(() =>
                {
                    databaseConnection.Insert(job);
                });
            }

            return Mapper.Map<JobDto>(job);
        }

        public int DeleteAllJobs()
        {
            using (var databaseConnection = new SQLiteConnection(new SQLitePlatformWP8(), this.DatabaseFilePath))
            {
                return databaseConnection.DeleteAll<Job>();
            }
        }
    }
}