using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductReviewAungAndBryant.Shared.Domain;
using System;

namespace ProductReviewAungAndBryant.Server.Configurations.Entities
{
    public class PcPartSeedConfiguration : IEntityTypeConfiguration<PcPart>
    {
        public void Configure(EntityTypeBuilder<PcPart> builder)
        {
            builder.HasData(
                new PcPart
                {
                    Id = 1,
                    PcPartName="Core i-9 14900KF",                   
                    PcPartPrice=850,               
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new PcPart
                {
                    Id = 2,
                    PcPartName= "RTX 4090",      
                    PcPartPrice = 2000,                
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
                
            );
        }
    }
}
