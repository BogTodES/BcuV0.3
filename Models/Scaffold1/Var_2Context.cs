using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BcuV0._3.Models.Scaffold1
{
    public partial class Var_2Context : IdentityDbContext
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
        public virtual DbSet<Sections> Sections { get; set; }
        public virtual DbSet<SectionsPosts> SectionsPosts { get; set; }
        public virtual DbSet<UserCommentReacts> UserCommentReacts { get; set; }
        public virtual DbSet<UserPostReacts> UserPostReacts { get; set; }
        public virtual DbSet<Varuti> Varuti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=BTODERICA;Initial Catalog=Var_2;Integrated Security=True");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(e => e.UserId);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(e => e.UserId);
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(e => e.UserId);

            modelBuilder.Entity<Blogs>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blogs_Varuti");
            });

            modelBuilder.Entity<BlogsSections>(entity =>
            {
                entity.HasKey(e => new { e.BlogId, e.SectionId });

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

                entity.Property(e => e.CommentId)
                    .HasColumnName("CommentID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Posts");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

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
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SectionsPosts>(entity =>
            {
                entity.HasKey(e => new { e.SectionId, e.PostId });

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

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(128);

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

            modelBuilder.Entity<UserPostReacts>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PostId, e.ReactId })
                    .HasName("PK_UserPostReacts_1");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(128);

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

            modelBuilder.Entity<Varuti>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(128);

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.Nume)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Prenume)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
