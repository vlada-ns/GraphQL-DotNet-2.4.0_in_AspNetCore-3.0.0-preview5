using GraphQL_1.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_1.SimonCropp
{
    // LocalDb is used to make the sample simpler.
    // Replace with a real DbContext
    public class DbContextBuilder
    {
        static AppDbContext database;
        static DbContextBuilder()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Server=VASIC;Database=AdventureWorks2016_EXT;Trusted_Connection=True;MultipleActiveResultSets=true;");
            var context = new AppDbContext(builder.Options);
            database = context;
        }

        public static AppDbContext BuildDbContext()
        {
            return database;
        }
    }
}
