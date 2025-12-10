using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LastMinuteTours.Entities;

namespace DataBaseStorage
{
    /// <inheritdoc/>
    internal class DataBaseContext : DbContext
    {
        /// <summary>
        /// Сущность <see cref="TourModel"/>.
        /// </summary>
        public DbSet<TourModel> TourModel { get; set; }

        /// <summary>
        /// Создаёт экземпляр <see cref="DataBaseContext"/>.
        /// </summary>
        public DataBaseContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=NailDatabase;Trusted_Connection=True;");
    }
}
