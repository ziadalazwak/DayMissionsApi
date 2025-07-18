using DayMissions.App.Interfaces;
using DayMissions.App.Services;
using DayMissions.Infrastructure.Reposatory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.Infrastructure.Configrations
{
    public static class Dbcontextconfig
    {
        public static IServiceCollection DbContextconf(this IServiceCollection services, IConfiguration config)
        {


            services.AddDbContext<DayMissionsDbcContext>(options =>
    options.UseSqlite(
        config.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("DayMissions.Infrastructure") // 👈 specify where migrations go
    ));
            
            services.AddScoped<ITaskReposatory,TaskReposatory>();
            services.AddScoped<IDailyTrackerReposatory,DailyTrackerReposatory>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITrackService, TrackService>();



            return services;

        }
    }
}