using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrecizeSoft.GetPdfOnline.Model;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite
{
    public partial class GetPdfOnlineDbContext : DbContext, IUnitOfWork
    {
        public GetPdfOnlineDbContext() :
            base(new DbContextOptionsBuilder().UseSqlite("Data Source=test.db").Options)
        {

        }

        public GetPdfOnlineDbContext(DbContextOptions<GetPdfOnlineDbContext> options) :
            base(options)
        {
        }

        public GetPdfOnlineDbContext(string connectionString) :
            base(new DbContextOptionsBuilder().UseSqlite(connectionString).Options)
        {

        }

        public DbSet<ConvertRequest> ConvertRequests { get; private set; }

        public DbSet<ConvertResponse> ConvertResponses { get; private set; }

        public DbSet<ConvertResultType> ConvertResultTypes { get; private set; }

        public DbSet<FileCategory> FileCategories { get; private set; }

        public DbSet<FileType> FileTypes { get; private set; }

        public DbSet<ConvertLog> ConvertLogs { get; private set; }

        public DbSet<ConvertStatByFileCategory> ConvertStatByFileCategory { get; private set; }

        public DbSet<ConvertStatTotal> ConvertStatTotal { get; private set; }

        public DbSet<ConvertStatByHour> ConvertStatByHour { get; private set; }

        /// <summary>
        /// Allows saving changes via the IUnitOfWork interface.
        /// </summary>
        void IUnitOfWork.SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            this.SetupFileCategories(modelBuilder);
            this.SetupFileTypes(modelBuilder);
            this.SetupConvertResultTypes(modelBuilder);
            this.SetupConvertRequests(modelBuilder);
            this.SetupConvertResponses(modelBuilder);
            this.SetupConvertLogs(modelBuilder);
            this.SetupConvertStatByFileCategory(modelBuilder);
            this.SetupConvertStatTotal(modelBuilder);
            this.SetupConvertStatByHour(modelBuilder);
        }

        private void SetupFileCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileCategory>().ToTable("tbFileCategories");

            modelBuilder.Entity<FileCategory>().HasKey(p => new { p.FileCategoryId });
            modelBuilder.Entity<FileCategory>().Property(p => p.FileCategoryId).ValueGeneratedNever();
            modelBuilder.Entity<FileCategory>().HasIndex(p => new { p.FileCategoryId }).IsUnique();

            modelBuilder.Entity<FileCategory>().Property(p => p.FileCategoryCode).IsRequired();
            modelBuilder.Entity<FileCategory>().HasAlternateKey(p => new { p.FileCategoryCode });
            modelBuilder.Entity<FileCategory>().HasIndex(p => new { p.FileCategoryCode }).IsUnique();
        }

        private void SetupFileTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileType>().ToTable("tbFileTypes");

            modelBuilder.Entity<FileType>().HasKey(p => new { p.FileTypeId });
            modelBuilder.Entity<FileType>().Property(p => p.FileTypeId).ValueGeneratedNever();
            modelBuilder.Entity<FileType>().HasIndex(p => new { p.FileTypeId }).IsUnique();

            modelBuilder.Entity<FileType>().Property(p => p.FileExtension).IsRequired();
            modelBuilder.Entity<FileType>().HasAlternateKey(p => new { p.FileExtension });
            modelBuilder.Entity<FileType>().HasIndex(p => new { p.FileExtension }).IsUnique();

            modelBuilder.Entity<FileType>().Property(p => p.FileCategoryId).IsRequired();
            modelBuilder.Entity<FileType>().HasIndex(p => new { p.FileCategoryId });
            modelBuilder.Entity<FileType>().HasOne(p => p.FileCategory).WithMany(p => p.FileTypes)
                .HasForeignKey(p => p.FileCategoryId).HasPrincipalKey(p => p.FileCategoryId)
                .OnDelete(DeleteBehavior.Restrict).IsRequired();
        }

        private void SetupConvertResultTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConvertResultType>().ToTable("tbConvertResultTypes");

            modelBuilder.Entity<ConvertResultType>().HasKey(p => new { p.ConvertResultTypeId });
            modelBuilder.Entity<ConvertResultType>().Property(p => p.ConvertResultTypeId).ValueGeneratedNever();
            modelBuilder.Entity<ConvertResultType>().HasIndex(p => new { p.ConvertResultTypeId }).IsUnique();

            modelBuilder.Entity<ConvertResultType>().Property(p => p.ConvertResultTypeCode).IsRequired();
            modelBuilder.Entity<ConvertResultType>().HasAlternateKey(p => new { p.ConvertResultTypeCode });
            modelBuilder.Entity<ConvertResultType>().HasIndex(p => new { p.ConvertResultTypeCode }).IsUnique();
        }

        private void SetupConvertRequests(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConvertRequest>().ToTable("tbConvertRequests");

            modelBuilder.Entity<ConvertRequest>().HasKey(p => new { p.ConvertRequestId });
            modelBuilder.Entity<ConvertRequest>().Property(p => p.ConvertRequestId).ValueGeneratedNever();
            modelBuilder.Entity<ConvertRequest>().HasIndex(p => new { p.ConvertRequestId }).IsUnique();

            modelBuilder.Entity<ConvertRequest>().Property(p => p.RequestDateUtc).IsRequired().ForSqliteHasColumnType("REAL");
            modelBuilder.Entity<ConvertRequest>().HasIndex(p => new { p.RequestDateUtc });

            modelBuilder.Entity<ConvertRequest>().Property(p => p.SenderIp).IsRequired();
            modelBuilder.Entity<ConvertRequest>().HasIndex(p => new { p.SenderIp });

            modelBuilder.Entity<ConvertRequest>().Property(p => p.FileExtension);
            modelBuilder.Entity<ConvertRequest>().HasIndex(p => new { p.FileExtension });

            modelBuilder.Entity<ConvertRequest>().Property(p => p.FileTypeId).IsRequired();
            modelBuilder.Entity<ConvertRequest>().HasIndex(p => new { p.FileTypeId });
            modelBuilder.Entity<ConvertRequest>().HasOne(p => p.FileType).WithMany(p => p.ConvertRequests)
                .HasForeignKey(p => p.FileTypeId).HasPrincipalKey(p => p.FileTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConvertRequest>().Property(p => p.FileSize).IsRequired();

            modelBuilder.Entity<ConvertRequest>().Property(p => p.CustomAttributes);
        }

        private void SetupConvertResponses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConvertResponse>().ToTable("tbConvertResponses");

            modelBuilder.Entity<ConvertResponse>().HasKey(p => new { p.ConvertResponseId });
            modelBuilder.Entity<ConvertResponse>().Property(p => p.ConvertResponseId).ValueGeneratedNever();
            modelBuilder.Entity<ConvertResponse>().HasIndex(p => new { p.ConvertResponseId }).IsUnique();
            modelBuilder.Entity<ConvertResponse>().HasOne(p => p.Request).WithOne(p => p.Response)
                .HasForeignKey<ConvertResponse>(p => p.ConvertResponseId)
                .HasPrincipalKey<ConvertRequest>(p => p.ConvertRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConvertResponse>().Property(p => p.ResponseDateUtc).IsRequired().ForSqliteHasColumnType("REAL");
            modelBuilder.Entity<ConvertResponse>().HasIndex(p => new { p.ResponseDateUtc });

            modelBuilder.Entity<ConvertResponse>().Property(p => p.ResultTypeId);
            modelBuilder.Entity<ConvertResponse>().HasIndex(p => new { p.ResultTypeId });
            modelBuilder.Entity<ConvertResponse>().HasOne(p => p.ResultType).WithMany(p => p.ConvertResponses)
                .HasForeignKey(p => p.ResultTypeId).HasPrincipalKey(p => p.ConvertResultTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConvertRequest>().Property(p => p.FileSize).IsRequired();
        }

        private void SetupConvertLogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConvertLog>().ToTable("vwConvertLogs");

            modelBuilder.Entity<ConvertLog>().HasKey(p => new { p.ConvertRequestId });
            modelBuilder.Entity<ConvertLog>().Property(p => p.ConvertRequestId).ValueGeneratedNever();
        }

        private void SetupConvertStatByFileCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConvertStatByFileCategory>().ToTable("vwConvertStatByFileCategory");

            modelBuilder.Entity<ConvertStatByFileCategory>().HasKey(p => new { p.FileCategoryId });
            modelBuilder.Entity<ConvertStatByFileCategory>().Property(p => p.FileCategoryId).ValueGeneratedNever();
        }

        private void SetupConvertStatTotal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConvertStatTotal>().ToTable("vwConvertStatTotal");

            modelBuilder.Entity<ConvertStatTotal>().HasKey(p => new { p.ConvertStatTotalId });
            modelBuilder.Entity<ConvertStatTotal>().Property(p => p.ConvertStatTotalId).ValueGeneratedNever();
        }

        private void SetupConvertStatByHour(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConvertStatByHour>().ToTable("vwConvertStatByHour");

            modelBuilder.Entity<ConvertStatByHour>().HasKey(p => new { p.BeginRequestDateUtc });
            modelBuilder.Entity<ConvertStatByHour>().Property(p => p.BeginRequestDateUtc).ValueGeneratedNever();
        }
    }
}