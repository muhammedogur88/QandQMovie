using AutoMapper;
using MovieWorkerService.Config;
using MovieWorkerService.Data;
using MovieWorkerService.Entities;
using MovieWorkerService.Entities.Db;
using MovieWorkerService.Repo;
using System.Text.Json;

namespace MovieWorkerService
{
    public class Worker : BackgroundService
    {
        static readonly HttpClient client = new HttpClient();
        private readonly MovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;


        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, IMapper mapper, DataContext context)
        {
            _logger = logger;
            _context = context;
            _movieRepository = new MovieRepository(_context);
            _mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var page = 1;

                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://api.themoviedb.org/3/movie/popular?api_key=e59751b97b051fb1d06e8ce620c77423&language=en-US&page={page}");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    MovieList list = JsonSerializer.Deserialize<MovieList>(responseBody);

                    var listMovie = _mapper.Map<List<Movie>>(list.MoviesDto);
                    _movieRepository.AddRange(listMovie);
                    _movieRepository.SaveChange();

                    Console.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }

                await Task.Delay(1000, stoppingToken);

            }
        }
    }
}