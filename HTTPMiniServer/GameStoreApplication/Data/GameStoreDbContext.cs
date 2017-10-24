namespace HTTPMiniServer.GameStoreApplication.Data
{
   using Microsoft.EntityFrameworkCore;
   using Models;

   public class GameStoreDbContext: DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder builder)
       {

          builder.UseSqlServer("Server=BALTPC;Database=GameStore;Integrated security ");

       }


       protected override void OnModelCreating(ModelBuilder builder)
       {
         
          builder.Entity<UserGame>().HasKey(ug => new {ug.GameId, ug.UserId});

          builder.Entity<User>()
            .HasIndex(u=>u.Email)
            .IsUnique();

          builder.Entity<User>()
             .HasMany(u => u.Games)
             .WithOne(ug => ug.User)
             .HasForeignKey(ug => ug.UserId);

          builder.Entity<Game>()
            .HasMany(g => g.Users)
            .WithOne(ug => ug.Game)
            .HasForeignKey(ug => ug.GameId);

       }
    }
}
