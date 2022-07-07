using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieWorkerService;
using MovieWorkerService.Data;
using MovieWorkerService.Repo;
using System;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
services.AddHostedService<Worker>();
        services.AddSingleton<DataContext>();
        //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    })
    .Build();


await host.RunAsync();


