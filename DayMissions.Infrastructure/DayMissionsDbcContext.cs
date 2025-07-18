using DayMissions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.Infrastructure
{
    public class DayMissionsDbcContext:DbContext
    {
        public DayMissionsDbcContext(DbContextOptions<DayMissionsDbcContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<TaskDefination> Tasks { get; set; }
        public DbSet <DailyTrack> Tracks {  get; set; }
    }
}
