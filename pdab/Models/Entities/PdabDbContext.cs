using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pdab.Models.Entities;

public partial class PdabDbContext : DbContext
{
    public PdabDbContext()
    {
    }

    public PdabDbContext(DbContextOptions<PdabDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<CargoType> CargoTypes { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<CrewAssignment> CrewAssignments { get; set; }

    public virtual DbSet<CrewMember> CrewMembers { get; set; }

    public virtual DbSet<FuelLog> FuelLogs { get; set; }

    public virtual DbSet<Port> Ports { get; set; }

    public virtual DbSet<PortFee> PortFees { get; set; }

    public virtual DbSet<Rank> Ranks { get; set; }

    public virtual DbSet<Ship> Ships { get; set; }

    public virtual DbSet<ShipCargo> ShipCargos { get; set; }

    public virtual DbSet<ShipInspection> ShipInspections { get; set; }

    public virtual DbSet<ShipMaintenance> ShipMaintenances { get; set; }

    public virtual DbSet<ShipRoute> ShipRoutes { get; set; }

    public virtual DbSet<ShipType> ShipTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=pdab_db;Integrated Security=True;Encrypt=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.CargoId).HasName("PK__Cargo__B4E665CD340A7DAE");

            entity.ToTable("Cargo");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Type).HasMaxLength(100);
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<CargoType>(entity =>
        {
            entity.HasKey(e => e.CargoTypeId).HasName("PK__CargoTyp__87BCCBD9E6C5390B");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Contract__C90D3469B7A99654");

            entity.Property(e => e.ContractDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(200);
            entity.Property(e => e.DeliveryDeadline).HasColumnType("datetime");

            entity.HasOne(d => d.Cargo).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contracts__Cargo__70DDC3D8");

            entity.HasOne(d => d.Ship).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contracts__ShipI__71D1E811");
        });

        modelBuilder.Entity<CrewAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__CrewAssi__32499E776CE98A68");

            entity.HasOne(d => d.CrewMember).WithMany(p => p.CrewAssignments)
                .HasForeignKey(d => d.CrewMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CrewAssig__CrewM__6477ECF3");

            entity.HasOne(d => d.Route).WithMany(p => p.CrewAssignments)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CrewAssig__Route__6383C8BA");
        });

        modelBuilder.Entity<CrewMember>(entity =>
        {
            entity.HasKey(e => e.CrewMemberId).HasName("PK__CrewMemb__BE4E6E6CB13C4F7C");

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Rank).HasMaxLength(100);

            entity.HasOne(d => d.Ship).WithMany(p => p.CrewMembers)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CrewMembe__ShipI__534D60F1");
        });

        modelBuilder.Entity<FuelLog>(entity =>
        {
            entity.HasKey(e => e.FuelLogId).HasName("PK__FuelLogs__FFEFAACBF6C541D1");

            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.FuelType).HasMaxLength(100);
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Ship).WithMany(p => p.FuelLogs)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FuelLogs__ShipId__6A30C649");
        });

        modelBuilder.Entity<Port>(entity =>
        {
            entity.HasKey(e => e.PortId).HasName("PK__Ports__D859BF8F767D28D0");

            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<PortFee>(entity =>
        {
            entity.HasKey(e => e.FeeId).HasName("PK__PortFees__B387B229C5F7D6C0");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Port).WithMany(p => p.PortFees)
                .HasForeignKey(d => d.PortId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PortFees__PortId__6D0D32F4");

            entity.HasOne(d => d.Ship).WithMany(p => p.PortFees)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PortFees__ShipId__6E01572D");
        });

        modelBuilder.Entity<Rank>(entity =>
        {
            entity.HasKey(e => e.RankId).HasName("PK__Ranks__B37AF8767852342A");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Ship>(entity =>
        {
            entity.HasKey(e => e.ShipId).HasName("PK__Ships__2A05CAB3FA6DD461");

            entity.Property(e => e.Flag).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Type).HasMaxLength(100);
        });

        modelBuilder.Entity<ShipCargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShipCarg__3214EC071D148D60");

            entity.ToTable("ShipCargo");

            entity.HasOne(d => d.Cargo).WithMany(p => p.ShipCargos)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipCargo__Cargo__59063A47");

            entity.HasOne(d => d.Ship).WithMany(p => p.ShipCargos)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipCargo__ShipI__5812160E");
        });

        modelBuilder.Entity<ShipInspection>(entity =>
        {
            entity.HasKey(e => e.InspectionId).HasName("PK__ShipInsp__30B2DC0882922270");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.InspectorName).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.Ship).WithMany(p => p.ShipInspections)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipInspe__ShipI__6754599E");
        });

        modelBuilder.Entity<ShipMaintenance>(entity =>
        {
            entity.HasKey(e => e.MaintenanceId).HasName("PK__ShipMain__E60542D53E7CEB69");

            entity.ToTable("ShipMaintenance");

            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.Ship).WithMany(p => p.ShipMaintenances)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipMaint__ShipI__5BE2A6F2");
        });

        modelBuilder.Entity<ShipRoute>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PK__ShipRout__80979B4D1A1681A7");

            entity.Property(e => e.ArrivalDate).HasColumnType("datetime");
            entity.Property(e => e.DepartureDate).HasColumnType("datetime");

            entity.HasOne(d => d.ArrivalPort).WithMany(p => p.ShipRouteArrivalPorts)
                .HasForeignKey(d => d.ArrivalPortId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipRoute__Arriv__60A75C0F");

            entity.HasOne(d => d.DeparturePort).WithMany(p => p.ShipRouteDeparturePorts)
                .HasForeignKey(d => d.DeparturePortId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipRoute__Depar__5FB337D6");

            entity.HasOne(d => d.Ship).WithMany(p => p.ShipRoutes)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipRoute__ShipI__5EBF139D");
        });

        modelBuilder.Entity<ShipType>(entity =>
        {
            entity.HasKey(e => e.ShipTypeId).HasName("PK__ShipType__72DCD0B806D8F41E");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
