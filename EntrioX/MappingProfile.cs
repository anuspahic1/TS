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
                 .ForMember(dest => dest.Address,
                     opt => opt.MapFrom(src => $"{src.Name}, {src.Address}"));

            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.LocationName,
                    opt => opt.MapFrom(src => src.Location != null ? src.Location.Name : ""));

            CreateMap<Ticket, TicketDto>()
                .ForMember(dest => dest.EventName,
                    opt => opt.MapFrom(src => src.Event != null ? src.Event.Name : ""))
                .ForMember(dest => dest.EventDate,
                    opt => opt.MapFrom(src => src.Event != null ? src.Event.EventDate : DateTime.MinValue));

            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.UserFullName,
                    opt => opt.MapFrom(src => src.User != null ? src.User.FullName : ""))
                .ForMember(dest => dest.EventName,
                    opt => opt.MapFrom(src => src.Event != null ? src.Event.Name : ""))
                .ForMember(dest => dest.EventDate,
                    opt => opt.MapFrom(src => src.Event != null ? src.Event.EventDate : DateTime.MinValue))
                .ForMember(dest => dest.TicketsCount,
                    opt => opt.MapFrom(src => src.Tickets != null ? src.Tickets.Count : 0));

            CreateMap<Reward, RewardDto>()
                .ForMember(dest => dest.UserFullName,
                    opt => opt.MapFrom(src => src.User != null ? src.User.FullName : ""));

            CreateMap<EventForCreationDto, Event>();

            CreateMap<LocationForCreationDto, Location>();

            CreateMap<AppUserForCreationDto, AppUser>();

            CreateMap<TicketForCreationDto, Ticket>();

            CreateMap<ReservationForCreationDto, Reservation>();

            CreateMap<RewardForCreationDto, Reward>();

            CreateMap<AppUserForUpdateDto, AppUser>();
            CreateMap<AppUserForUpdateDto, AppUser>().ReverseMap();
            CreateMap<LocationForUpdateDto, Location>();
            CreateMap<LocationForUpdateDto, Location>().ReverseMap();
            CreateMap<RewardForUpdateDto, Reward>();
            CreateMap<RewardForUpdateDto, Reward>().ReverseMap();
            CreateMap<EventForUpdateDto, Event>().ForMember(dest => dest.LocationId, opt => opt.Ignore());
            CreateMap<EventForUpdateDto, Event>().ReverseMap();
            CreateMap<TicketForUpdateDto, Ticket>();
            CreateMap<TicketForUpdateDto, Ticket>().ReverseMap();
            CreateMap<UserForRegistrationDto, User>();

        }
    }
}
