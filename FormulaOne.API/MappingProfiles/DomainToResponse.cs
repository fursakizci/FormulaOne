using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Responses;

namespace FormulaOne.API.MappingProfiles;

public class DomainToResponse:Profile
{
    public DomainToResponse()
    {
        CreateMap<Achievement, DriverAchievementsResponse>()
            .ForMember(
                dest => dest.Wins,
                opt => opt.MapFrom(src => src.RaceWins))
            ;

        CreateMap<Driver, GetDriverResponse>()
            .ForMember(dest=>dest.DriverId,
                opt=>opt.MapFrom(src=>src.Id))
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName}{src.LastName}"))
            ;
    }

}
