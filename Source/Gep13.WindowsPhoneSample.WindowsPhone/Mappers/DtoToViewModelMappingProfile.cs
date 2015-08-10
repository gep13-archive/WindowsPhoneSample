namespace Gep13.WindowsPhoneSample.WindowsPhone.Mappers
{
    using AutoMapper;
    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.WindowsPhone.ViewModel;

    public class DtoToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DtoToViewModelMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<JobDto, JobViewModel>();
        }
    }
}