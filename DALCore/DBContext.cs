
namespace DALCore
{
    using Microsoft.EntityFrameworkCore;

    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLog>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
