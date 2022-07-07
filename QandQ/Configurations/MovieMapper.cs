using AutoMapper;
using QandQ.DTOs;
using QandQ.Entities;
using System.Reflection;

namespace QandQ.Configurations
{
    public class MovieMapper : Profile
    {
        public MovieMapper()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<MovieRateAndNote, MovieRateAndNoteDto>().ReverseMap();
            CreateMap<User, UserDto>();

        }
    }
}
