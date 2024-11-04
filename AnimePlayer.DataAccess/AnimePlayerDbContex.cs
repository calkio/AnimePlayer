using AnimePlayer.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace AnimePlayer.DataAccess
{
    public class AnimePlayerDbContex : DbContext
    {
        public AnimePlayerDbContex(DbContextOptions<AnimePlayerDbContex> options) : base(options)
        {
        }

        public DbSet<AnimeEntites> Animes { get; set; }
    }
}
