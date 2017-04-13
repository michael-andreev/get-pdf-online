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

        public DbSet<ResultFile> ResultFiles { get; set; }

        public DbSet<ResultFileContent> ResultFilesContent { get; set; }

        void IUnitOfWork.SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            this.SetupResultFiles(modelBuilder);
            this.SetupResultFilesContent(modelBuilder);
        }

        private void SetupResultFiles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResultFile>().ToTable("tbResultFiles");

            modelBuilder.Entity<ResultFile>().HasKey(p => new { p.ResultFileId });
            modelBuilder.Entity<ResultFile>().Property(p => p.ResultFileId).ValueGeneratedNever();
            modelBuilder.Entity<ResultFile>().HasIndex(p => new { p.ResultFileId }).IsUnique();

            modelBuilder.Entity<ResultFile>().Property(p => p.CreateDateUtc).IsRequired().ForSqliteHasColumnType("REAL");
            modelBuilder.Entity<ResultFile>().HasIndex(p => new { p.CreateDateUtc });

            modelBuilder.Entity<ResultFile>().Property(p => p.ExpireDateUtc).IsRequired().ForSqliteHasColumnType("REAL");
            modelBuilder.Entity<ResultFile>().HasIndex(p => new { p.ExpireDateUtc });

            modelBuilder.Entity<ResultFile>().Property(p => p.SessionId);
            modelBuilder.Entity<ResultFile>().HasIndex(p => new { p.SessionId });

            modelBuilder.Entity<ResultFile>().Property(p => p.FileName).IsRequired();
        }

        private void SetupResultFilesContent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResultFileContent>().ToTable("tbResultFilesContent");

            modelBuilder.Entity<ResultFileContent>().HasKey(p => new { p.ResultFileContentId });
            modelBuilder.Entity<ResultFileContent>().Property(p => p.ResultFileContentId).ValueGeneratedNever();
            modelBuilder.Entity<ResultFileContent>().HasIndex(p => new { p.ResultFileContentId }).IsUnique();
            modelBuilder.Entity<ResultFileContent>().HasOne(p => p.ResultFile).WithOne(p => p.Content)
                .HasForeignKey<ResultFileContent>(p => p.ResultFileContentId)
                .HasPrincipalKey<ResultFile>(p => p.ResultFileId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResultFileContent>().Property(p => p.FileBytes).IsRequired();
        }

    }
}
