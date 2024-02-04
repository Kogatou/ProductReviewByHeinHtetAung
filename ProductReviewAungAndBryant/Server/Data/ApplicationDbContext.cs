using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductReviewAungAndBryant.Server.Configurations.Entities;
using ProductReviewAungAndBryant.Server.Models;
using ProductReviewAungAndBryant.Shared.Domain;

namespace ProductReviewAungAndBryant.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        //public DbSet<Review> Reviews { get; set; } 

        public DbSet<PcPart> PcParts { get; set; }

        //public DbSet<Reviewer> Reviewers {  get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryPcPart> CategoryPcParts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.ApplyConfiguration(new ReviewerSeedConfiguration());
            builder.ApplyConfiguration(new PcPartSeedConfiguration());
            // builder.ApplyConfiguration(new ReviewSeedConfiguration());
            builder.ApplyConfiguration(new CategorySeedConfiguration());
        }
    }
}
