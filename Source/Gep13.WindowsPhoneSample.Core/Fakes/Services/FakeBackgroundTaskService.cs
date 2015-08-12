namespace Gep13.WindowsPhoneSample.Core.Fakes.Services
{
    using System.Threading.Tasks;
    using Gep13.WindowsPhoneSample.Core.Services;

    public class FakeBackgroundTaskService : IBackgroundTaskService
    {
        public Task ActivateService()
        {
            throw new System.NotImplementedException();
        }

        public Task DeactivateService()
        {
            throw new System.NotImplementedException();
        }
    }
}