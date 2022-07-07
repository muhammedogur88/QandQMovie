using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QandQ.Data;
using QandQ.DTOs;
using QandQ.Entities;
using System.Security.Claims;

namespace QandQ.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MoviesController(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetUserName() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

        [HttpGet("{page}/{pageSize}")]
        public async Task<ActionResult<List<MovieDto>>> GetMovies(int page, int pageSize)
        {
            if (_context.Movies == null)
                return NotFound();

            var pageResults = (float)pageSize;
            var pageCount = Math.Ceiling(_context.Movies.Count() / pageResults);

            var movies = await _context.Movies
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var list = _mapper.Map<List<MovieDto>>(movies);

            var response = new MoviesResponseDto
            {
                Movies = list,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return Ok(response);
        }

        [HttpGet("movieId")]
        public async Task<ActionResult<MovieDto>> GetMovieDetail(int movieId)
        {
            if (_context.Movies == null)
                return NotFound();
            var userName = GetUserName();

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Username == userName);
            Guid userId = new Guid("d0f47c82-9e0a-4ea0-a331-517f5822de1d");

            var movie = await _context.Movies.Include(m => m.MovieRateAndNote.Where(s => s.UserId == user.Id))
                .Where(x => x.Id == movieId).FirstOrDefaultAsync();
            var movieDto = _mapper.Map<MovieDto>(movie);
            return Ok(movieDto);
        }

        [HttpPost]
        [Route("movierateandnote")]
        public async Task<ActionResult<MovieRateAndNoteDto>> AddMovieRateAndNote(MovieRateAndNoteDto movieRateAndNoteDto)
        {
            var data = _mapper.Map<MovieRateAndNote>(movieRateAndNoteDto);
            data.Id = Guid.NewGuid();

            await _context.MovieRateAndNote.AddAsync(data);
            _context.SaveChanges();

            return Ok(movieRateAndNoteDto);
        }

    }
}
