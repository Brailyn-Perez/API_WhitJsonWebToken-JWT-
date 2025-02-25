using API_WhitJsonWebToken_JWT_.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_WhitJsonWebToken_JWT_.API.Context;

public partial class ApiJwtContext : DbContext
{
    public ApiJwtContext()
    {
    }

    public ApiJwtContext(DbContextOptions<ApiJwtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC2743B14303");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27DA0D83AA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("E-mail");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
