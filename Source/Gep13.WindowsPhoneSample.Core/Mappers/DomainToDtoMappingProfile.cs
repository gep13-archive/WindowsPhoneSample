namespace Gep13.WindowsPhoneSample.Core.Mappers
{
    using AutoMapper;
    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Model;

    public class DomainToDtoMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToDtoMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Job, JobDto>();
        }
    }
}