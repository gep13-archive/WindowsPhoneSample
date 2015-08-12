namespace Gep13.WindowsPhoneSample.Core.Services
{
    using System.Threading.Tasks;

    public interface IBackgroundTaskService
    {
        Task ActivateService();

        Task DeactivateService();
    }
}