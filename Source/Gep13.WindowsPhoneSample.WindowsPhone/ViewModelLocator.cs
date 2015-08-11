namespace Gep13.WindowsPhoneSample.WindowsPhone
{
    using GalaSoft.MvvmLight.Ioc;
    using Gep13.WindowsPhoneSample.Core.Mappers;
    using Gep13.WindowsPhoneSample.Core.Repository;
    using Gep13.WindowsPhoneSample.Core.Services;
    using Gep13.WindowsPhoneSample.Core.ViewModel;
    using Microsoft.Practices.ServiceLocation;

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IJobRepository, JobRepository>();
            SimpleIoc.Default.Register<IJobService, JobService>();

            SimpleIoc.Default.Register(
                () =>
                    {
                        var context = new Gep13DataContext();
                        context.OnCreate(App.DatabaseFilePath);
                        return context;
                    },
                true);

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