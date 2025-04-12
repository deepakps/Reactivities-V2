using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    /// <summary>
    /// The application's database context, used for interacting with the data store.
    /// </summary>
    /// <param name="options"></param>
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        #region Properties
        /// <summary>
        /// Represents the Activities table in the database.
        /// </summary>
        public required DbSet<Activity> Activities { get; set; }
        #endregion
    }
}   