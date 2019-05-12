using System.Linq;
using AutoMapper;
using Logotech.API.Dtos;
using Logotech.API.Models;

/* Classe permettant de faire un mapping entre les modèles de données de l'applications et la couche de donnée utilisée pour le transfers vers le front end en fonction
des besoins de l'application Angular gérant le front end de l'application Logotech. */

namespace Logotech.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            /* Mapping docteurs */

            CreateMap<Docteur, DocteurForListDto>();
            CreateMap<Docteur, DocteurForDetailDto>();

            /* Mapping patients */

            CreateMap<Patient, PatientForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                });
            CreateMap<Patient, PatientForDetailDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                });
            CreateMap<PatientForUpdateDto, Patient>();

            /* Mapping photos */

            CreateMap<Photo, PhotoForDetailDto>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();

            /* Mapping logopèdes, utilisateurs de l'application actuellement */

            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailDto>();            
            CreateMap<UserForRegisterDto, User>();
        }
    }
}