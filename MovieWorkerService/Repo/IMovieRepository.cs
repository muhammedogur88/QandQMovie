using MovieWorkerService.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWorkerService.Repo
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
    }
}
