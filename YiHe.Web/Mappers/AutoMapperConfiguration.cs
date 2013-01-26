using AutoMapper;


namespace YiHe.Web.Mappers
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
                              {
                                  x.AddProfile<DomainToModelMappingProfile>();
                                  x.AddProfile<DomainToViewModelMappingProfile>();
                                  x.AddProfile<ViewModelToDomainMappingProfile>();
                              });
        }
    }
}