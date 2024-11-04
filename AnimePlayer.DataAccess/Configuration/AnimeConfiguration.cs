using AnimePlayer.Core.Models;
using AnimePlayer.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimePlayer.DataAccess.Configuration
{
    public class AnimeConfiguration : IEntityTypeConfiguration<AnimeEntites>
    {
        public void Configure(EntityTypeBuilder<AnimeEntites> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(a => a.Title)
                   .HasMaxLength(Anime.MAX_COUNT_SYMBOL_TITLE)
                   .IsRequired();

            builder.Property(a => a.Description)
                   .IsRequired();

            builder.Property(a => a.YearIssue)
                   .IsRequired();
        }
    }
}
