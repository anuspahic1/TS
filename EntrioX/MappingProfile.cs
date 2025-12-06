using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace EntrioX
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserDto>();

            CreateMap<Location, LocationDto>()
                .ForCtorParam("FullAddress",
                     opt => opt.MapFrom(src => $"{src.Name}, {src.Address}"));

            CreateMap<Event, EventDto>()
                .ForCtorParam("LocationName",
                    opt => opt.MapFrom(src => src.Location != null ? src.Location.Name : ""));

            CreateMap<Ticket, TicketDto>()
                .ForMember(dest => dest.EventName,
                    opt => opt.MapFrom(src => src.Event != null ? src.Event.Name : "")) ;

            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.UserFullName,
                    opt => opt.MapFrom(src => src.User != null ? src.User.FullName : ""))
                .ForMember(dest => dest.EventName,
                    opt => opt.MapFrom(src => src.Event != null ? src.Event.Name : ""));

            CreateMap<Reward, RewardDto>()
                .ForMember(dest => dest.UserFullName,
                    opt => opt.MapFrom(src => src.User != null ? src.User.FullName : ""));
        }
    }
}
