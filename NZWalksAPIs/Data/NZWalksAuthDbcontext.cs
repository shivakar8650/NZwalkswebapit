using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalksAPIs.Data
{
    public class NZWalksAuthDbcontext : IdentityDbContext
    {
        public NZWalksAuthDbcontext( DbContextOptions<NZWalksAuthDbcontext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "eeffb72f-a960-4e93-8cf0-ff523bafe415";
            var writerRoleId = "2a12a82a-ca6d-4408-903b-60ad170b5d94";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id  = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name  = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name  = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
