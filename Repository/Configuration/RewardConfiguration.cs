using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class RewardConfiguration : IEntityTypeConfiguration<Reward>
    {
        public void Configure(EntityTypeBuilder<Reward> builder)
        {
            builder.HasData(
                new Reward
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    UserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Description = "Early supporter reward",
                    ImageUrl = "/images/rewards/supporter.png",
                    GrantedAt = new DateTime(2026, 1, 1)
                },
                new Reward
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    UserId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    Description = "Top buyer of the month",
                    ImageUrl = "/images/rewards/topbuyer.png",
                    GrantedAt = new DateTime(2026, 1, 1)
                }
            );
        }
    }
}
