namespace Gep13.WindowsPhoneSample.Core.Mappers
{
    using System;
    using AutoMapper;

    public static class AutoMapperConfiguration
    {
        public static void Configure(Func<Type, object> servicesConstructor = null)
        {
            Mapper.Initialize(mapper =>
            {
                if (servicesConstructor != null)
                {
                    mapper.ConstructServicesUsing(servicesConstructor);
                }

                mapper.AddProfile<DomainToDtoMappingProfile>();
                mapper.AddProfile<DtoToDomainMappingProfile>();
                mapper.AddProfile<DtoToViewModelMappingProfile>();
            });
        }
    }
}