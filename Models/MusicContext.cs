using Microsoft.EntityFrameworkCore;

namespace MusicDemo.Models
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options) { }

        public DbSet<Music> Musics { get; set; } = null;
    }
}
