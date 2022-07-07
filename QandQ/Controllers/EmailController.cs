using Microsoft.AspNetCore.Mvc;
using QandQ.Data;
using QandQ.DTOs;
using QandQ.Services;

namespace QandQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly DataContext _context;

        public EmailController(IEmailService emailService, DataContext context)
        {
            _emailService = emailService;
            _context = context;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }

        [HttpPost("recommendedmovie")]
        public IActionResult SendRecomendedMovieWithEmail(RecomendedMovieDto request)
        {
            var data = new EmailDto();
            data.To = request.To;
            data.Subject = request.Subject;
            var movie = _context.Movies.FirstOrDefault(a => a.Id == request.movieId);
            var movieText =
                $"<p>Movie Name : {movie.Title}</p>" +
                $"<p>Movie Overview : {movie.Overview}</p>" +
                $"<p>Movie Popularity : {movie.Popularity}</p>" +
                $"<p>Movie Rate {movie.VoteAverage}</p>";
            data.Body = movieText;
            _emailService.SendEmail(data);
            return Ok();
        }

    }
}
