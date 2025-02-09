using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HORSES.Models;

public partial class HorseCompetitionsContext : DbContext
{
    public HorseCompetitionsContext()
    {
    }

    public HorseCompetitionsContext(DbContextOptions<HorseCompetitionsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CheckIn> CheckIns { get; set; }

    public virtual DbSet<CheckInResult> CheckInResults { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<ClothesSet> ClothesSets { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<CompetitionAndCheckIn> CompetitionAndCheckIns { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Horse> Horses { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<PlaceBirth> PlaceBirths { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<TypHorse> TypHorses { get; set; }

    public virtual DbSet<TypeCheckIn> TypeCheckIns { get; set; }

    public virtual DbSet<UserI> UserIs { get; set; }

    public virtual DbSet<Violation> Violations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HORSE_COMPETITIONS;Username=postgres;Password=123");
        optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<CheckIn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("check_in_pkey");

            entity.ToTable("check_in");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age)
                .HasColumnType("character varying")
                .HasColumnName("age");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.Distance).HasColumnName("distance");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PlaceBirthIdCollection)
                .HasColumnType("character varying")
                .HasColumnName("place_birth_id_collection");
            entity.Property(e => e.PrizeFund).HasColumnName("prize_fund");
            entity.Property(e => e.SequenceNumber).HasColumnName("sequence_number");
            entity.Property(e => e.TimeStart).HasColumnName("time_start");
            entity.Property(e => e.TypeCheckInId).HasColumnName("type_check_in_id");
            entity.Property(e => e.TypeHorseIdCollection)
                .HasColumnType("character varying")
                .HasColumnName("type_horse_id_collection");

            entity.HasOne(d => d.TypeCheckIn).WithMany(p => p.CheckIns)
                .HasForeignKey(d => d.TypeCheckInId)
                .HasConstraintName("check_in_type_check_in_id_fkey");
        });

        modelBuilder.Entity<CheckInResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("check_in_result_pkey");

            entity.ToTable("check_in_result");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckInId).HasColumnName("check_in_id");
            entity.Property(e => e.Indicator)
                .HasColumnType("character varying")
                .HasColumnName("indicator");
            entity.Property(e => e.ParticipantId).HasColumnName("participant_id");
            entity.Property(e => e.Result).HasColumnName("result");
            entity.Property(e => e.TimeEnd).HasColumnName("time_end");

            entity.HasOne(d => d.CheckIn).WithMany(p => p.CheckInResults)
                .HasForeignKey(d => d.CheckInId)
                .HasConstraintName("check_in_result_check_in_id_fkey");

            entity.HasOne(d => d.Participant).WithMany(p => p.CheckInResults)
                .HasForeignKey(d => d.ParticipantId)
                .HasConstraintName("check_in_result_participant_id_fkey");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("city_pkey");

            entity.ToTable("city");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<ClothesSet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clothes_set_pkey");

            entity.ToTable("clothes_set");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HelmetColor)
                .HasColumnType("character varying")
                .HasColumnName("helmet_color");
            entity.Property(e => e.HelmetForm)
                .HasColumnType("character varying")
                .HasColumnName("helmet_form");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("company_pkey");

            entity.ToTable("company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("competition_pkey");

            entity.ToTable("competition");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.TimeStart).HasColumnName("time_start");
        });

        modelBuilder.Entity<CompetitionAndCheckIn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("competition_and_check_in_pkey");

            entity.ToTable("competition_and_check_in");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckInId).HasColumnName("check_in_id");
            entity.Property(e => e.CompetitionId).HasColumnName("competition_id");
            entity.Property(e => e.ParticipantId).HasColumnName("participant_id");
            entity.Property(e => e.TrackId).HasColumnName("track_id");

            entity.HasOne(d => d.CheckIn).WithMany(p => p.CompetitionAndCheckIns)
                .HasForeignKey(d => d.CheckInId)
                .HasConstraintName("competition_and_check_in_check_in_id_fkey");

            entity.HasOne(d => d.Competition).WithMany(p => p.CompetitionAndCheckIns)
                .HasForeignKey(d => d.CompetitionId)
                .HasConstraintName("competition_and_check_in_competition_id_fkey");

            entity.HasOne(d => d.Participant).WithMany(p => p.CompetitionAndCheckIns)
                .HasForeignKey(d => d.ParticipantId)
                .HasConstraintName("competition_and_check_in_participant_id_fkey");

            entity.HasOne(d => d.Track).WithMany(p => p.CompetitionAndCheckIns)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("competition_and_check_in_track_id_fkey");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("donation_pkey");

            entity.ToTable("donation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DonationSumm).HasColumnName("donation_summ");
            entity.Property(e => e.HorseId).HasColumnName("horse_id");

            entity.HasOne(d => d.Horse).WithMany(p => p.Donations)
                .HasForeignKey(d => d.HorseId)
                .HasConstraintName("donation_horse_id_fkey");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gender_pkey");

            entity.ToTable("gender");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Horse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("horse_pkey");

            entity.ToTable("horse");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PhyoTrener)
                .HasColumnType("character varying")
                .HasColumnName("phyo_trener");
            entity.Property(e => e.PlaceBirthId).HasColumnName("place_birth_id");
            entity.Property(e => e.TypId).HasColumnName("typ_id");

            entity.HasOne(d => d.Gender).WithMany(p => p.Horses)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("horse_gender_id_fkey");

            entity.HasOne(d => d.Owner).WithMany(p => p.Horses)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("horse_owner_id_fkey");

            entity.HasOne(d => d.PlaceBirth).WithMany(p => p.Horses)
                .HasForeignKey(d => d.PlaceBirthId)
                .HasConstraintName("horse_place_birth_id_fkey");

            entity.HasOne(d => d.Typ).WithMany(p => p.Horses)
                .HasForeignKey(d => d.TypId)
                .HasConstraintName("horse_typ_id_fkey");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("owner_pkey");

            entity.ToTable("owner");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Phyo)
                .HasColumnType("character varying")
                .HasColumnName("phyo");

            entity.HasOne(d => d.Company).WithMany(p => p.Owners)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("owner_company_id_fkey");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("participant_pkey");

            entity.ToTable("participant");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClothesSetId).HasColumnName("clothes_set_id");
            entity.Property(e => e.Disqualification)
                .HasDefaultValue(false)
                .HasColumnName("disqualification");
            entity.Property(e => e.HorseId).HasColumnName("horse_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ClothesSet).WithMany(p => p.Participants)
                .HasForeignKey(d => d.ClothesSetId)
                .HasConstraintName("participant_clothes_set_id_fkey");

            entity.HasOne(d => d.Horse).WithMany(p => p.Participants)
                .HasForeignKey(d => d.HorseId)
                .HasConstraintName("participant_horse_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Participants)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("participant_user_id_fkey");
        });

        modelBuilder.Entity<PlaceBirth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("place_birth_pkey");

            entity.ToTable("place_birth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("track_pkey");

            entity.ToTable("track");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Number)
                .HasColumnType("character varying")
                .HasColumnName("number");
        });

        modelBuilder.Entity<TypHorse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("typ_horse_pkey");

            entity.ToTable("typ_horse");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<TypeCheckIn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_check_in_pkey");

            entity.ToTable("type_check_in");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<UserI>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_is_pkey");

            entity.ToTable("user_is");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.DistinctCode).HasColumnName("distinct_code");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Phyo)
                .HasMaxLength(256)
                .HasColumnName("phyo");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Category).WithMany(p => p.UserIs)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("user_is_category_id_fkey");

            entity.HasOne(d => d.City).WithMany(p => p.UserIs)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("user_is_city_id_fkey");

            entity.HasOne(d => d.Gender).WithMany(p => p.UserIs)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("user_is_gender_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.UserIs)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("user_is_role_id_fkey");
        });

        modelBuilder.Entity<Violation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("violation_pkey");

            entity.ToTable("violation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ParticipantId).HasColumnName("participant_id");
            entity.Property(e => e.Violations)
                .HasColumnType("character varying")
                .HasColumnName("violations");

            entity.HasOne(d => d.Participant).WithMany(p => p.Violations)
                .HasForeignKey(d => d.ParticipantId)
                .HasConstraintName("violation_participant_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
