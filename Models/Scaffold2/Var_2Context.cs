using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BcuV0._3.Models.Scaffold2
{
    public partial class Var_2Context : DbContext
    {
        public Var_2Context()
        {
        }

        public Var_2Context(DbContextOptions<Var_2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<BlogsSections> BlogsSections { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<ReactTypes> ReactTypes { get; set; }
        public virtual DbSet<RoleClaims> RoleClaims { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sections> Sections { get; set; }
        public virtual DbSet<SectionsPosts> SectionsPosts { get; set; }
        public virtual DbSet<UserClaims> UserClaims { get; set; }
        public virtual DbSet<UserCommentReacts> UserCommentReacts { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<UserPostReacts> UserPostReacts { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<UserTokens> UserTokens { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Varuti> Varuti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogs>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blogs_Varuti");
            });

            modelBuilder.Entity<BlogsSections>(entity =>
            {
                entity.HasKey(e => new { e.BlogId, e.SectionId });

                entity.HasIndex(e => e.SectionId);

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogsSections)
                    .HasForeignKey(d => d.BlogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlogsSections_Sections");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.BlogsSections)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlogsSections_Sections1");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.HasIndex(e => e.PostId);

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Posts");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ReactTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Sections>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SectionsPosts>(entity =>
            {
                entity.HasKey(e => new { e.SectionId, e.PostId });

                entity.HasIndex(e => e.PostId);

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.SectionsPosts)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SectionsPosts_Posts");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.SectionsPosts)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SectionsPosts_Sections");
            });

            modelBuilder.Entity<UserCommentReacts>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CommentId, e.ReactId });

                entity.HasIndex(e => e.CommentId);

                entity.HasIndex(e => e.ReactId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.ReactId).HasColumnName("ReactID");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.UserCommentReacts)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCommentReacts_Comments");

                entity.HasOne(d => d.React)
                    .WithMany(p => p.UserCommentReacts)
                    .HasForeignKey(d => d.ReactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCommentReacts_ReactTypes");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCommentReacts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCommentReacts_Varuti");
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });

            modelBuilder.Entity<UserPostReacts>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PostId, e.ReactId })
                    .HasName("PK_UserPostReacts_1");

                entity.HasIndex(e => e.PostId);

                entity.HasIndex(e => e.ReactId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.ReactId).HasColumnName("ReactID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.UserPostReacts)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPostReacts_Posts");

                entity.HasOne(d => d.React)
                    .WithMany(p => p.UserPostReacts)
                    .HasForeignKey(d => d.ReactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPostReacts_ReactTypes");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPostReacts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPostReacts_Varuti");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });

            modelBuilder.Entity<UserTokens>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });

            modelBuilder.Entity<Varuti>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Prenume)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Varuti)
                    .HasForeignKey<Varuti>(d => d.Id)
                    .HasConstraintName("FK_Varuti_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
