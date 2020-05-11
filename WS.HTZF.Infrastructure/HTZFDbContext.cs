using MySql.Data.Entity;
using System.Data.Entity;
using System.Threading.Tasks;
using WS.HTZF.Core.SeedWorks;
using WS.HTZF.Infrastructure.EntityConfigurations;

namespace WS.HTZF.Infrastructure
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class HTZFDbContext : DbContext, IUnitOfWork
    {

        // Constructor - set name of connection
        public HTZFDbContext() : base("name=DefaultConnection")
        {
             Database.SetInitializer<HTZFDbContext>(new DBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new RoleMenuConfiguration());
            modelBuilder.Configurations.Add(new MenuConfiguration());

        }

        public new async Task<bool> SaveChangesAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}

