using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Khan.Common.Entities;
using Khan.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Khan.EntityFrameworkCore
{
    public class Khontext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public Khontext() { }
        public Khontext(DbContextOptions options) : base(options) { }

        #region [Overrides]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region [Configuration]
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
            #endregion

            #region [Relationship]
            modelBuilder.Entity<RoleEntity>()
                .HasOne(user => user.User)
                .WithOne(role => role.Role)
                .HasForeignKey<UserEntity>(c => c.RoleId);
            #endregion

            modelBuilder.HasDefaultSchema(schema: DBGlobals.SChemaName);

            #region [Seed]

            //Seeding Role's entities
            var roleCreatedDate = DateTime.Now;
            var roleIdSuperUser = Guid.NewGuid();
            var roleIdNormalUser = Guid.NewGuid();

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity
                {
                    RoleId = roleIdSuperUser,
                    CreatedDate = roleCreatedDate,
                    Deleted = false,
                    Level = 99,
                    Name = "Super Admin"
                },
                new RoleEntity
                {
                    RoleId = roleIdNormalUser,
                    CreatedDate = roleCreatedDate,
                    Deleted = false,
                    Level = 10,
                    Name = "User"
                }
            );

            //Seeding User's entities
            var userCreatedDate = DateTime.Now;
            var userIdSuperUser = Guid.NewGuid();
            var userIdNormalUser = Guid.NewGuid();
            var userIdUnactive = Guid.NewGuid();

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    UserId = userIdSuperUser,
                    Active = true,
                    FirstName = "Diego",
                    LastName = "Modesto",
                    CreatedDate = userCreatedDate,
                    Deleted = false,
                    Email = "diegosanches89@gmail.com",
                    Password = "@123mudar",
                    RoleId = roleIdSuperUser
                },
                new UserEntity
                {
                    UserId = userIdNormalUser,
                    Active = true,
                    FirstName = "Francisco",
                    LastName = "Almeida",
                    CreatedDate = userCreatedDate,
                    Deleted = false,
                    Email = "teste1@teste.com",
                    Password = "@123mudar",
                    RoleId = roleIdNormalUser
                },
                new UserEntity
                {
                    UserId = userIdUnactive,
                    Active = false,
                    FirstName = "Roberto",
                    LastName = "Machado de Castro",
                    CreatedDate = userCreatedDate,
                    Deleted = false,
                    Email = "teste2@teste.com",
                    Password = "@123mudar",
                    RoleId = roleIdNormalUser
                }
            );
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DBGlobals.DbConnection);
        }

        public override int SaveChanges()
        {
            this.Audit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.Audit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        #endregion

        /// <summary>
        /// Private audit to SaveChanges in DataBase
        /// </summary>
        private void Audit()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedDate = DateTime.UtcNow;
                    ((BaseEntity)entry.Entity).Deleted = false;
                }
            }
        }
    }
}
