using AutoMapper;
using DOCUMENTATION.APPLICATION.Mappers;

namespace DOCUMENTATION.IOC.Configurations
{
    public static class MapperExtensions
    {
        private static IMapper _mapper = new MapperConfiguration(cfg =>
          {
              cfg.AddProfile<TopicMapper>();
          }).CreateMapper();

        public static T Map<T>(this object obj)
        {
            return _mapper.Map<T>(obj);
        }
    }
}