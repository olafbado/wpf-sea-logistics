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

    public virtual DbSet<ShipTypeCargoType> ShipTypeCargoTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=OLAF;Initial Catalog=pdab_db;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cargo__3214EC277DD3D51A");

            entity.ToTable("Cargo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.CargoType).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.CargoTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cargo__CargoType__44FF419A");
        });

        modelBuilder.Entity<CargoType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CargoTyp__3214EC273D2B1B25");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__3214EC275F3DE21A");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ContractDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(200);
            entity.Property(e => e.DeliveryDeadline).HasColumnType("datetime");

            entity.HasOne(d => d.Cargo).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contracts__Cargo__52593CB8");
        });

        modelBuilder.Entity<CrewAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrewAssi__3214EC27AB92FCF2");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.CrewMember).WithMany(p => p.CrewAssignments)
                .HasForeignKey(d => d.CrewMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CrewAssig__CrewM__5BE2A6F2");

            entity.HasOne(d => d.ShipRoute).WithMany(p => p.CrewAssignments)
                .HasForeignKey(d => d.ShipRouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CrewAssig__ShipR__5AEE82B9");
        });

        modelBuilder.Entity<CrewMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrewMemb__3214EC273BFCC177");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);

            entity.HasOne(d => d.Rank).WithMany(p => p.CrewMembers)
                .HasForeignKey(d => d.RankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CrewMembe__RankI__4222D4EF");
        });

        modelBuilder.Entity<FuelLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FuelLogs__3214EC27486A2A28");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.FuelType).HasMaxLength(100);

            entity.HasOne(d => d.Ship).WithMany(p => p.FuelLogs)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FuelLogs__ShipId__619B8048");
        });

        modelBuilder.Entity<Port>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ports__3214EC27623F9A6D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<PortFee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PortFees__3214EC27225F5D7E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Port).WithMany(p => p.PortFees)
                .HasForeignKey(d => d.PortId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PortFees__PortId__6477ECF3");

            entity.HasOne(d => d.Ship).WithMany(p => p.PortFees)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PortFees__ShipId__656C112C");
        });

        modelBuilder.Entity<Rank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ranks__3214EC2774CC1035");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Ship>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ships__3214EC278C00DC39");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Flag).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.ShipType).WithMany(p => p.Ships)
                .HasForeignKey(d => d.ShipTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ships__ShipTypeI__3F466844");
        });

        modelBuilder.Entity<ShipCargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShipCarg__3214EC27386758AC");

            entity.ToTable("ShipCargo");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Cargo).WithMany(p => p.ShipCargos)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipCargo__Cargo__48CFD27E");

            entity.HasOne(d => d.Ship).WithMany(p => p.ShipCargos)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipCargo__ShipI__47DBAE45");
        });

        modelBuilder.Entity<ShipInspection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShipInsp__3214EC271CA8600D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.InspectorName).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(500);

            entity.HasOne(d => d.Ship).WithMany(p => p.ShipInspections)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipInspe__ShipI__5EBF139D");
        });

        modelBuilder.Entity<ShipMaintenance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShipMain__3214EC271614E7CE");

            entity.ToTable("ShipMaintenance");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.Ship).WithMany(p => p.ShipMaintenances)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipMaint__ShipI__4F7CD00D");
        });

        modelBuilder.Entity<ShipRoute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShipRout__3214EC2794CD425E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArrivalDate).HasColumnType("datetime");
            entity.Property(e => e.DepartureDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.ArrivalPort).WithMany(p => p.ShipRouteArrivalPorts)
                .HasForeignKey(d => d.ArrivalPortId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipRoute__Arriv__571DF1D5");

            entity.HasOne(d => d.Contract).WithMany(p => p.ShipRoutes)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipRoute__Contr__5812160E");

            entity.HasOne(d => d.DeparturePort).WithMany(p => p.ShipRouteDeparturePorts)
                .HasForeignKey(d => d.DeparturePortId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipRoute__Depar__5629CD9C");

            entity.HasOne(d => d.Ship).WithMany(p => p.ShipRoutes)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipRoute__ShipI__5535A963");
        });

        modelBuilder.Entity<ShipType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShipType__3214EC27A1945BD0");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ShipTypeCargoType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShipType__3214EC273D1BA3C1");

            entity.ToTable("ShipTypeCargoType");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.CargoType).WithMany(p => p.ShipTypeCargoTypes)
                .HasForeignKey(d => d.CargoTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipTypeC__Cargo__4CA06362");

            entity.HasOne(d => d.ShipType).WithMany(p => p.ShipTypeCargoTypes)
                .HasForeignKey(d => d.ShipTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShipTypeC__ShipT__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
