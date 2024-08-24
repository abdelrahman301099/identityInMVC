using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using webapplicationday8.Models;

namespace webapplicationday8.Context
{
    public class DrugContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Drug> Drugs { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public DrugContext() : base()
        {

        }
        public DrugContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            

            //set conditions/contrains that can be set in the database
            modelBuilder.Entity<Drug>(
                bldr =>
                {
                    //bldr.HasOne<Department>().WithMany(d=>d.Students).HasForeignKey(s=>s.DepartmentID);
                    bldr.HasKey(s => s.ID);
                    bldr.Property(s => s.Name).IsRequired().HasMaxLength(50);
                    bldr.HasOne(s => s.Company).WithMany(d => d.Drugs).HasForeignKey(s => s.CompanyID);

                }

                );
            modelBuilder.Entity<Company>(
                blder =>
                {
                    blder.Property(c => c.Name).HasMaxLength(30);


                }
                );

        }
        public DbSet<webapplicationday8.Models.User> User { get; set; } = default!;

    }
}
