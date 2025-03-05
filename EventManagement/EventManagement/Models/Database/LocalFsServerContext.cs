using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Models.Database;

public partial class LocalFsServerContext : DbContext
{
    public LocalFsServerContext()
    {
    }

    public LocalFsServerContext(DbContextOptions<LocalFsServerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<ImagesCity> ImagesCities { get; set; }

    public virtual DbSet<ImagesCity1> ImagesCities1 { get; set; }

    public virtual DbSet<Jury> Juries { get; set; }

    public virtual DbSet<Moderator> Moderators { get; set; }

    public virtual DbSet<ModeratorsEvent> ModeratorsEvents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserState> UserStates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=localFsServer;Username=freps;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activities_pk");

            entity.ToTable("activities");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.FifthJuryId).HasColumnName("fifth_jury_id");
            entity.Property(e => e.FirstJuryId).HasColumnName("first_jury_id");
            entity.Property(e => e.FourthJuryId).HasColumnName("fourth_jury_id");
            entity.Property(e => e.ModeratorId).HasColumnName("moderator_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.NumberDay).HasColumnName("number_day");
            entity.Property(e => e.SecondJuryId).HasColumnName("second_jury_id");
            entity.Property(e => e.ThirdJuryId).HasColumnName("third_jury_id");
            entity.Property(e => e.TimeStart).HasColumnName("time_start");

            entity.HasOne(d => d.Event).WithMany(p => p.Activities)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("activities_events_fk");

            entity.HasOne(d => d.FifthJury).WithMany(p => p.ActivityFifthJuries)
                .HasForeignKey(d => d.FifthJuryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("activities_jury_fk_4");

            entity.HasOne(d => d.FirstJury).WithMany(p => p.ActivityFirstJuries)
                .HasForeignKey(d => d.FirstJuryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("activities_jury_fk");

            entity.HasOne(d => d.FourthJury).WithMany(p => p.ActivityFourthJuries)
                .HasForeignKey(d => d.FourthJuryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("activities_jury_fk_3");

            entity.HasOne(d => d.Moderator).WithMany(p => p.Activities)
                .HasForeignKey(d => d.ModeratorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("activities_moderators_fk");

            entity.HasOne(d => d.SecondJury).WithMany(p => p.ActivitySecondJuries)
                .HasForeignKey(d => d.SecondJuryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("activities_jury_fk_1");

            entity.HasOne(d => d.ThirdJury).WithMany(p => p.ActivityThirdJuries)
                .HasForeignKey(d => d.ThirdJuryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("activities_jury_fk_2");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cities_pk");

            entity.ToTable("cities");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("countries_pk");

            entity.ToTable("countries");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.EnglishName)
                .HasColumnType("character varying")
                .HasColumnName("english_name");
            entity.Property(e => e.FirstCode)
                .HasColumnType("character varying")
                .HasColumnName("first_code");
            entity.Property(e => e.RussianName)
                .HasColumnType("character varying")
                .HasColumnName("russian_name");
            entity.Property(e => e.SecondCode).HasColumnName("second_code");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("direction_pk");

            entity.ToTable("direction");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pk");

            entity.ToTable("events");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.DateEvent).HasColumnName("date_event");
            entity.Property(e => e.Days).HasColumnName("days");
            entity.Property(e => e.ImagePath)
                .HasColumnType("character varying")
                .HasColumnName("image_path");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.WinnerId).HasColumnName("winner_id");

            entity.HasOne(d => d.City).WithMany(p => p.Events)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("events_cities_fk");

            entity.HasOne(d => d.Winner).WithMany(p => p.Events)
                .HasForeignKey(d => d.WinnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("events_users_fk");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genders_pk");

            entity.ToTable("genders");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<ImagesCity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("images_cities_pk");

            entity.ToTable("images_cities");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.NameId).HasColumnName("name_id");

            entity.HasOne(d => d.Image).WithMany(p => p.ImagesCities)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("images_cities_images_city_fk");

            entity.HasOne(d => d.Name).WithMany(p => p.ImagesCities)
                .HasForeignKey(d => d.NameId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("images_cities_cities_fk");
        });

        modelBuilder.Entity<ImagesCity1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("images_city_pk");

            entity.ToTable("images_city");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ImagePath)
                .HasColumnType("character varying")
                .HasColumnName("image_path");
        });

        modelBuilder.Entity<Jury>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jury_pk");

            entity.ToTable("jury");

            entity.HasIndex(e => e.UserId, "unique_user_id_jury").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.DirectionId).HasColumnName("direction_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Direction).WithMany(p => p.Juries)
                .HasForeignKey(d => d.DirectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("jury_direction_fk");

            entity.HasOne(d => d.User).WithOne(p => p.Jury)
                .HasForeignKey<Jury>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("jury_users_fk");
        });

        modelBuilder.Entity<Moderator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("moderators_pk");

            entity.ToTable("moderators");

            entity.HasIndex(e => e.UserId, "moderators_user_id_idx");

            entity.HasIndex(e => e.UserId, "unique_user_id_moderators").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.DirectionId).HasColumnName("direction_id");
            entity.Property(e => e.ModeratorEventId).HasColumnName("moderator_event_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Direction).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.DirectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("moderators_direction_fk");

            entity.HasOne(d => d.ModeratorEvent).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.ModeratorEventId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("moderators_moderators_events_fk");

            entity.HasOne(d => d.User).WithOne(p => p.Moderator)
                .HasForeignKey<Moderator>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("moderators_users_fk");
        });

        modelBuilder.Entity<ModeratorsEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("moderators_events_pk");

            entity.ToTable("moderators_events");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pk");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasColumnType("character varying")
                .HasColumnName("full_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.ImagePath)
                .HasColumnType("character varying")
                .HasColumnName("image_path");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.StateId).HasColumnName("state_id");

            entity.HasOne(d => d.Country).WithMany(p => p.Users)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("users_countries_fk");

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("users_genders_fk");

            entity.HasOne(d => d.State).WithMany(p => p.Users)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("users_states_fk");
        });

        modelBuilder.Entity<UserState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_states_pk");

            entity.ToTable("user_states");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
