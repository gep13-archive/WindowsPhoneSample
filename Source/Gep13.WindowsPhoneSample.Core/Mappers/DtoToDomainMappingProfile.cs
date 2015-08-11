namespace Gep13.WindowsPhoneSample.Core.Mappers
{
    using AutoMapper;
    using Gep13.WindowsPhoneSample.Core.Dto;
    using Gep13.WindowsPhoneSample.Core.Model;

    public class DtoToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DtoToDomainMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<JobDto, Job>();
        }
    }
}