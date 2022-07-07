using MovieWorkerService.Data;
using MovieWorkerService.Entities.Db;

namespace MovieWorkerService.Repo
{
    public class MovieRepository : GenericRepository<Movie>
    {
        public MovieRepository(DataContext context) : base(context)
        {
        }
        
    }
}
