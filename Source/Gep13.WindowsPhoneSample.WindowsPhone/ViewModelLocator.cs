namespace Gep13.WindowsPhoneSample.WindowsPhone
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Ioc;
    using Gep13.WindowsPhoneSample.Core.Fakes.Repository;
    using Gep13.WindowsPhoneSample.Core.Fakes.Services;
    using Gep13.WindowsPhoneSample.Core.Mappers;
    using Gep13.WindowsPhoneSample.Core.Repository;
    using Gep13.WindowsPhoneSample.Core.Services;
    using Gep13.WindowsPhoneSample.Core.ViewModel;
    using Gep13.WindowsPhoneSample.WindowsPhone.Services;

    using Microsoft.Practices.ServiceLocation;

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Register ViewModels
            SimpleIoc.Default.Register<MainViewModel>();

            // Register Services
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IJobService, JobService>();
                SimpleIoc.Default.Register<IBackgroundTaskService, BackgroundTaskService>();
            }
            else
            {
                SimpleIoc.Default.Register<IJobService, FakeJobService>();
                SimpleIoc.Default.Register<IBackgroundTaskService, FakeBackgroundTaskService>();
            }

            // Register Repositories
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IJobRepository, JobRepository>();
            }
            else
            {
                SimpleIoc.Default.Register<IJobRepository, FakeJobRepository>();
            }

            // Register instances
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register(
                    () =>
                        {
                            var context = new Gep13DataContext();
                            context.OnCreate(App.DatabaseFilePath);
                            return context;
                        },
                    true);
            }

            AutoMapperConfiguration.Configure(null);
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}