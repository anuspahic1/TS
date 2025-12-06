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
                .ForMember(dest => dest.FullAddress,
                    opt => opt.MapFrom(src => $"{src.Name}, {src.Address}"));

            CreateMap<Event, EventDto>()
            .ForMember(dest => dest.LocationName,
                opt => opt.MapFrom(src => src.Location.Name));

            CreateMap<Ticket, TicketDto>()
                .ForMember(dest => dest.EventName,
                    opt => opt.MapFrom(src => src.Event.Name));

            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.UserFullName,
                    opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.EventName,
                    opt => opt.MapFrom(src => src.Event.Name));

            CreateMap<Reward, RewardDto>()
                .ForMember(dest => dest.UserFullName,
                    opt => opt.MapFrom(src => src.User.FullName));
        }
    }
}
