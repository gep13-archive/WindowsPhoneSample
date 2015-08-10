namespace Gep13.WindowsPhoneSample.WindowsPhone.Mappers
{
    using System;

    using AutoMapper;

    using Gep13.WindowsPhoneSample.Core.Mappers;

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

                mapper.AddProfile<DtoToViewModelMappingProfile>();
            });
        }
    }
}