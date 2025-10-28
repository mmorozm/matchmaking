using Matchmaking.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Matchmaking.Migrations.Data;

public class MatchmakingDbContext : DbContext
{
    public MatchmakingDbContext(DbContextOptions<MatchmakingDbContext> options) : base(options) { }
    
    public DbSet<Scenario> Scenarios { get; set; }
    
    public DbSet<Playlist> Playlists { get; set; }
    
    public DbSet<PlatformGroup> Platforms { get; set; }
    
    public DbSet<Ticket> Tickets { get; set; }
    
    public DbSet<Match> Matches { get; set; }

    public DbSet<MatchReservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SetupPlatformGroupTable(modelBuilder);

        SetupTicketTable(modelBuilder);

        SetupMatchTable(modelBuilder);

        SetupPlaylistsAndScenarios(modelBuilder);
        
        SetupMatchReservations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void SetupMatchReservations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MatchReservation>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<MatchReservation>()
            .HasOne(r => r.Ticket)
            .WithOne(t => t.Reservation)
            .HasForeignKey<MatchReservation>(r => r.TicketId);
        
        modelBuilder.Entity<MatchReservation>()
            .HasOne(r => r.Match)
            .WithMany(m => m.Reservations)
            .HasForeignKey(r => r.MatchId);
    }

    private void SetupPlaylistsAndScenarios(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Scenario>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<Playlist>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<Playlist>()
            .Property(x => x.PlaylistType)
            .IsRequired();

        modelBuilder.Entity<Playlist>()
            .Property(x => x.Score)
            .HasDefaultValue(0);
        
        modelBuilder.Entity<Playlist>()
            .HasMany(p => p.Scenarios)
            .WithOne(s => s.Playlist)
            .HasForeignKey(s => s.PlaylistId);
    }

    private void SetupPlatformGroupTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlatformGroup>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<PlatformGroup>()
            .Property(p => p.Group)
            .IsRequired();
    }

    private void SetupMatchTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Match>()
            .Property(x => x.Region)
            .IsRequired();
        
        modelBuilder.Entity<Match>()
            .Property(x => x.SupportedInputs)
            .IsRequired();
        
        modelBuilder.Entity<Match>()
            .HasOne(m => m.Platform)
            .WithMany()
            .HasForeignKey(m => m.PlatformId)
            .IsRequired();

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Playlist)
            .WithMany()
            .HasForeignKey(m => m.PlaylistId);
        
        modelBuilder.Entity<Match>()
            .HasOne(m => m.Scenario)
            .WithMany()
            .HasForeignKey(m => m.ScenarioId);
    }

    private void SetupTicketTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<Ticket>()
            .Property(x => x.State)
            .IsRequired();
        
        modelBuilder.Entity<Ticket>()
            .Property(x => x.Regions)
            .IsRequired();
        
        modelBuilder.Entity<Ticket>()
            .Property(x => x.Size)
            .IsRequired();
        
        modelBuilder.Entity<Ticket>()
            .Property(x => x.SelectedInput)
            .IsRequired();
        
        modelBuilder.Entity<Ticket>()
            .Property(x => x.OriginalInput)
            .IsRequired();
        
        modelBuilder.Entity<Ticket>()
            .Property(x => x.Party)
            .IsRequired();
        
        modelBuilder.Entity<Ticket>()
            .Property(x => x.PlayerId)
            .IsRequired();
        
        modelBuilder.Entity<Ticket>()
            .Property(x => x.TimeCreated)
            .IsRequired();

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.LateJoinTicket)
            .WithMany(t => t.ChildTickets)
            .HasForeignKey(t => t.LateJoinTicketId)
            .IsRequired(false);
    }
}