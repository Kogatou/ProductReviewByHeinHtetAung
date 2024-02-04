using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductReviewAungAndBryant.Shared.Domain;
using System;

namespace ProductReviewAungAndBryant.Server.Configurations.Entities
{
    public class ReviewerSeedConfiguration : IEntityTypeConfiguration<Reviewer>
    {
        public void Configure(EntityTypeBuilder<Reviewer> builder)
        {
            builder.HasData(
                new Reviewer
                {
                    Id = 1,
                    ReviewerName = "Koike12",
                    ReviewerEmail="Koike12@gmail.com",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Reviewer
                {
                    Id = 2, 
                    ReviewerName = "Peko111",
                    ReviewerEmail = "Peko1111@gmail.com",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }, new Reviewer
                {
                    Id = 3,
                    ReviewerName = "Koike123",
                    ReviewerEmail = "Koike123@gmail.com",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Reviewer
                {
                    Id = 4,
                    ReviewerName = "Peko1113",
                    ReviewerEmail = "Peko11113@gmail.com",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
            );
        }
    }
}

