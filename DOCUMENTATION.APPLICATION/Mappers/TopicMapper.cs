using AutoMapper;
using DOCUMENTATION.APPLICATION.ModelView.TopicView;
using DOCUMENTATION.CORE.Entities;

namespace DOCUMENTATION.APPLICATION.Mappers
{
    public class TopicMapper : Profile
    {
        public TopicMapper()
        {
            AllowNullCollections = true;

            CreateMap<Topic, TopicView>()
                .ForMember(dest => dest.Title, cfg => cfg.MapFrom(source => source.Title))
                .ForMember(dest => dest.Description, cfg => cfg.MapFrom(source => source.Description))
                .ForMember(dest => dest.Creation, cfg => cfg.MapFrom(source => source.DateCreation))
                .ForMember(dest => dest.Topics, cfg => cfg.MapFrom(source => source.Topics));

        }
    }
}
