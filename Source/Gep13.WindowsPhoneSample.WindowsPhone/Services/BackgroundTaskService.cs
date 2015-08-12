namespace Gep13.WindowsPhoneSample.WindowsPhone.Services
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using GalaSoft.MvvmLight.Messaging;
    using Gep13.WindowsPhoneSample.Core;
    using Gep13.WindowsPhoneSample.Core.Services;
    using Gep13.WindowsPhoneSample.WindowsPhone.Resources;
    using Windows.ApplicationModel.Background;

    public class BackgroundTaskService : IBackgroundTaskService
    {
        private const string SystemEventTaskName = "SystemEventBackgroundTask";
        private const string SystemEventTaskEntryPoint = "Gep13.WindowsPhoneSample.BackgroundTasks.SystemEventBackgroundTask";

        public async Task ActivateService()
        {
            try
            {
                await this.RegisterTasks();
            }
            catch (Exception ex)
            {
                // Should probably log this somewhere...
            }
        }

        public async Task DeactivateService()
        {
            try
            {
                await this.UnregisterTasks();
            }
            catch (Exception ex)
            {
                // Should probably log this somewhere...
            }
        }

        private async Task RegisterTasks()
        {
            // Applications must have lock screen privileges in order to receive raw notifications
            var backgroundStatus = await BackgroundExecutionManager.RequestAccessAsync();

            // Make sure the user allowed privileges
            if (backgroundStatus != BackgroundAccessStatus.Denied && backgroundStatus != BackgroundAccessStatus.Unspecified)
            {
                var systemEventTaskBuilder = new BackgroundTaskBuilder();
                var systemEventTrigger = new SystemTrigger(SystemTriggerType.InternetAvailable, false);
                systemEventTaskBuilder.AddCondition(new SystemCondition(SystemConditionType.InternetAvailable));
                systemEventTaskBuilder.SetTrigger(systemEventTrigger);

                // Background tasks must live in separate DLL, and be included in the package manifest
                // Also, make sure that your main application project includes a reference to this DLL
                systemEventTaskBuilder.TaskEntryPoint = SystemEventTaskEntryPoint;
                systemEventTaskBuilder.Name = SystemEventTaskName;

                try
                {
                    var task = systemEventTaskBuilder.Register();
                    task.Completed += this.SystemEventBackgroundTaskCompleted;
                }
                catch (Exception ex)
                {
                    // Should probably log this somewhere...
                }
            }
            else
            {
                // Should probably log this somewhere...
            }
        }

        private Task<bool> UnregisterTasks()
        {
            foreach (var iter in BackgroundTaskRegistration.AllTasks)
            {
                var task = iter.Value;
                if (task.Name == SystemEventTaskName)
                {
                    task.Unregister(true);
                    return Task.FromResult(true);
                }
            }

            return Task.FromResult(false);
        }

        private void SystemEventBackgroundTaskCompleted(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                Messenger.Default.Send(new NotificationMessage(Constants.Messages.SystemEventBackgroundTaskCompleted));
            });
        }
    }
}