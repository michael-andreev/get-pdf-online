using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrecizeSoft.GetPdfOnline.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite
{
    public partial class CacheDbContext : DbContext, IUnitOfWork
    {
        public CacheDbContext() :
            base(new DbContextOptionsBuilder().UseSqlite("Data Source=cache-init.db").Options)
        {

        }

        public CacheDbContext(DbContextOptions<CacheDbContext> options) :
            base(options)
        {
        }

        public CacheDbContext(string connectionString) :
            base(new DbContextOptionsBuilder().UseSqlite(connectionString).Options)
        {

        }

        public DbSet<BinaryFile> BinaryFiles { get; set; }

        public DbSet<BinaryFileContent> BinaryFilesContent { get; set; }

        public DbSet<ConvertJob> ConvertJobs { get; set; }

        public DbSet<ConvertSession> ConvertSessions { get; set; }

        void IUnitOfWork.SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            this.SetupBinaryFiles(modelBuilder);
            this.SetupBinaryFilesContent(modelBuilder);
            this.SetupConvertSessions(modelBuilder);
            this.SetupConvertJobs(modelBuilder);
        }

        private void SetupBinaryFiles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinaryFile>().ToTable("tbFiles");

            modelBuilder.Entity<BinaryFile>().HasKey(p => new { p.FileId });
            modelBuilder.Entity<BinaryFile>().Property(p => p.FileId).ValueGeneratedNever();
            modelBuilder.Entity<BinaryFile>().HasIndex(p => new { p.FileId }).IsUnique();

            modelBuilder.Entity<BinaryFile>().Property(p => p.CreateDateUtc).IsRequired().ForSqliteHasColumnType("REAL");
            modelBuilder.Entity<BinaryFile>().HasIndex(p => new { p.CreateDateUtc });

            modelBuilder.Entity<BinaryFile>().Property(p => p.FileName).IsRequired();

            modelBuilder.Entity<BinaryFile>().Property(p => p.FileSize).IsRequired();
        }

        private void SetupBinaryFilesContent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinaryFileContent>().ToTable("tbFilesContent");

            modelBuilder.Entity<BinaryFileContent>().HasKey(p => new { p.FileContentId });
            modelBuilder.Entity<BinaryFileContent>().Property(p => p.FileContentId).ValueGeneratedNever();
            modelBuilder.Entity<BinaryFileContent>().HasIndex(p => new { p.FileContentId }).IsUnique();
            modelBuilder.Entity<BinaryFileContent>().HasOne(p => p.File).WithOne(p => p.Content)
                .HasForeignKey<BinaryFileContent>(p => p.FileContentId)
                .HasPrincipalKey<BinaryFile>(p => p.FileId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BinaryFileContent>().Property(p => p.FileBytes).IsRequired();
        }

        private void SetupConvertSessions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConvertSession>().ToTable("tbSessions");

            modelBuilder.Entity<ConvertSession>().HasKey(p => new { p.SessionId });
            modelBuilder.Entity<ConvertSession>().Property(p => p.SessionId).ValueGeneratedNever();
            modelBuilder.Entity<ConvertSession>().HasIndex(p => new { p.SessionId }).IsUnique();

            modelBuilder.Entity<ConvertSession>().Property(p => p.CreateDateUtc).IsRequired().ForSqliteHasColumnType("REAL");
            modelBuilder.Entity<ConvertSession>().HasIndex(p => new { p.CreateDateUtc });
        }

        private void SetupConvertJobs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConvertJob>().ToTable("tbConvertJobs");

            modelBuilder.Entity<ConvertJob>().HasKey(p => new { p.ConvertJobId });
            modelBuilder.Entity<ConvertJob>().Property(p => p.ConvertJobId).ValueGeneratedNever();
            modelBuilder.Entity<ConvertJob>().HasIndex(p => new { p.ConvertJobId }).IsUnique();

            modelBuilder.Entity<ConvertJob>().Property(p => p.ExpireDateUtc).IsRequired().ForSqliteHasColumnType("REAL");
            modelBuilder.Entity<ConvertJob>().HasIndex(p => new { p.ExpireDateUtc });

            modelBuilder.Entity<ConvertJob>().Property(p => p.SessionId);
            modelBuilder.Entity<ConvertJob>().HasIndex(p => new { p.SessionId });
            modelBuilder.Entity<ConvertJob>()
                .HasOne(p => p.Session)
                .WithMany(p => p.Jobs)
                .HasForeignKey(p => p.SessionId)
                .HasPrincipalKey(p => p.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ConvertJob>().Property(p => p.Rating);

            modelBuilder.Entity<ConvertJob>().Property(p => p.InputFileId).IsRequired();
            modelBuilder.Entity<ConvertJob>().HasIndex(p => new { p.InputFileId }).IsUnique();
            modelBuilder.Entity<ConvertJob>().HasOne(p => p.InputFile).WithOne(p => p.ConvertJobOnInput)
                .HasForeignKey<ConvertJob>(p => p.InputFileId)
                .HasPrincipalKey<BinaryFile>(p => p.FileId)
                .OnDelete(DeleteBehavior.Restrict).IsRequired();

            modelBuilder.Entity<ConvertJob>().Property(p => p.OutputFileId);
            modelBuilder.Entity<ConvertJob>().HasIndex(p => new { p.OutputFileId }).IsUnique();
            modelBuilder.Entity<ConvertJob>().HasOne(p => p.OutputFile).WithOne(p => p.ConvertJobOnOutput)
                .HasForeignKey<ConvertJob>(p => p.OutputFileId)
                .HasPrincipalKey<BinaryFile>(p => p.FileId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConvertJob>().Property(p => p.ErrorTypeId);
            modelBuilder.Entity<ConvertJob>().HasIndex(p => new { p.ErrorTypeId });
        }
    }
}
