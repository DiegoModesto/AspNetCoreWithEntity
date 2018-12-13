using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Khan.EntityFrameworkCore
{
    public class KhanFactory : IDesignTimeDbContextFactory<Khontext>
    {
        public Khontext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Khontext>();
            optionsBuilder.UseSqlServer(DBGlobals.DbConnection);

            return new Khontext(optionsBuilder.Options);
        }
    }
}
