using AutoMapper;

namespace UserManagement.Business.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Create()
        {
            var builder = new MapperConfiguration(RegisterMappings);
            builder.AssertConfigurationIsValid();

            return builder.CreateMapper();
        }

        public static void RegisterMappings(IMapperConfigurationExpression config)
        {
            config.AddProfile<ToUser>();
        }
    }
}
