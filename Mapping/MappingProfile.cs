using ApplicationFormTask.DTOs;
using ApplicationFormTask.Models;
using AutoMapper;

namespace ApplicationFormTask.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Programs, ProgramDto>().ReverseMap();
            CreateMap<PersonalInformation, PersonalInformationDto>().ReverseMap();
            CreateMap<CustomQuestion, CustomQuestionDto>().ReverseMap();
        }
    }
}
