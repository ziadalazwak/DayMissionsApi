using DayMissions.App.Interfaces;
using DayMissions.App.Services;
using DayMissions.Infrastructure.Reposatory;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayMissions.Infrastructure.Services;

namespace DayMissions.Infrastructure.Configrations
{
    public static class Dbcontextconfig
    {
        public static IServiceCollection DbContextconf(this IServiceCollection services, IConfiguration config)
        {


            services.AddDbContext<DayMissionsDbcContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));







            services.AddScoped<ITaskReposatory,TaskReposatory>();
            services.AddScoped<IDailyTrackerReposatory,DailyTrackerReposatory>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<IAuthService,AuthService>();



            return services;

        }
    }
}