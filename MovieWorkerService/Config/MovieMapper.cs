using AutoMapper;
using MovieWorkerService.Entities;
using MovieWorkerService.Entities.Db;

namespace MovieWorkerService.Config
{
    public class MovieMapper : Profile
    {
        public MovieMapper()
        {
            CreateMap<MovieDto, Movie>();
        }
    }
}
