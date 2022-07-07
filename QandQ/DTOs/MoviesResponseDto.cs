using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandQ.DTOs
{
    public class MoviesResponseDto
    {
        public List<MovieDto> Movies { get; set; } = new List<MovieDto>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
