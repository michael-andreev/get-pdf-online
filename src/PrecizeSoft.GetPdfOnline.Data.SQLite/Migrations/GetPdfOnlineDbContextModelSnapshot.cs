using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PrecizeSoft.GetPdfOnline.Data.SQLite;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Migrations
{
    [DbContext(typeof(GetPdfOnlineDbContext))]
    partial class GetPdfOnlineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.ConvertLog", b =>
                {
                    b.Property<Guid>("ConvertRequestId");

                    b.Property<string>("CustomAttributes");

                    b.Property<double?>("DurationInSeconds");

                    b.Property<string>("FileCategoryCode");

                    b.Property<int>("FileCategoryId");

                    b.Property<string>("FileExtension");

                    b.Property<int>("FileSize");

                    b.Property<int>("FileTypeId");

                    b.Property<DateTimeOffset>("RequestDateUtc");

                    b.Property<DateTimeOffset?>("ResponseDateUtc");

                    b.Property<int?>("ResultFileSize");

                    b.Property<string>("ResultTypeCode");

                    b.Property<int>("ResultTypeId");

                    b.Property<string>("SenderIp");

                    b.HasKey("ConvertRequestId");

                    b.ToTable("vwConvertLogs");
                });

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.ConvertRequest", b =>
                {
                    b.Property<Guid>("ConvertRequestId");

                    b.Property<string>("CustomAttributes");

                    b.Property<string>("FileExtension");

                    b.Property<int>("FileSize");

                    b.Property<int>("FileTypeId");

                    b.Property<DateTimeOffset>("RequestDateUtc")
                        .HasAnnotation("Sqlite:ColumnType", "REAL");

                    b.Property<string>("SenderIp")
                        .IsRequired();

                    b.HasKey("ConvertRequestId");

                    b.HasIndex("ConvertRequestId")
                        .IsUnique();

                    b.HasIndex("FileExtension");

                    b.HasIndex("FileTypeId");

                    b.HasIndex("RequestDateUtc");

                    b.HasIndex("SenderIp");

                    b.ToTable("tbConvertRequests");
                });

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.ConvertResponse", b =>
                {
                    b.Property<Guid>("ConvertResponseId");

                    b.Property<DateTimeOffset>("ResponseDateUtc")
                        .HasAnnotation("Sqlite:ColumnType", "REAL");

                    b.Property<int?>("ResultFileSize");

                    b.Property<int>("ResultTypeId");

                    b.HasKey("ConvertResponseId");

                    b.HasIndex("ConvertResponseId")
                        .IsUnique();

                    b.HasIndex("ResponseDateUtc");

                    b.HasIndex("ResultTypeId");

                    b.ToTable("tbConvertResponses");
                });

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.ConvertResultType", b =>
                {
                    b.Property<int>("ConvertResultTypeId");

                    b.Property<string>("ConvertResultTypeCode")
                        .IsRequired();

                    b.HasKey("ConvertResultTypeId");

                    b.HasAlternateKey("ConvertResultTypeCode");

                    b.HasIndex("ConvertResultTypeCode")
                        .IsUnique();

                    b.HasIndex("ConvertResultTypeId")
                        .IsUnique();

                    b.ToTable("tbConvertResultTypes");
                });

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.ConvertStatByFileCategory", b =>
                {
                    b.Property<int>("FileCategoryId");

                    b.Property<string>("FileCategoryCode");

                    b.Property<int>("FileSizeAvg");

                    b.Property<int>("FileSizeMax");

                    b.Property<int>("FileSizeMin");

                    b.Property<long>("FileSizeSum");

                    b.Property<int>("TotalCount");

                    b.HasKey("FileCategoryId");

                    b.ToTable("vwConvertStatByFileCategory");
                });

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.ConvertStatByHour", b =>
                {
                    b.Property<DateTimeOffset>("BeginRequestDateUtc");

                    b.Property<DateTimeOffset>("EndRequestDateUtc");

                    b.Property<long>("FileSizeSum");

                    b.Property<long>("ResultFileSizeSum");

                    b.Property<int>("TotalCount");

                    b.Property<long>("TotalFileSizeSum");

                    b.Property<int>("UtcMinutesOffset");

                    b.HasKey("BeginRequestDateUtc");

                    b.ToTable("vwConvertStatByHour");
                });

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.ConvertStatTotal", b =>
                {
                    b.Property<int>("ConvertStatTotalId");

                    b.Property<double>("DurationInSecondsAvg");

                    b.Property<double>("DurationInSecondsMax");

                    b.Property<double>("DurationInSecondsMin");

                    b.Property<int>("FileSizeAvg");

                    b.Property<int>("FileSizeMax");

                    b.Property<int>("FileSizeMin");

                    b.Property<long>("FileSizeSum");

                    b.Property<DateTimeOffset?>("FirstRequestDateUtc");

                    b.Property<DateTimeOffset?>("LastRequestDateUtc");

                    b.Property<int>("NegativeResultCount");

                    b.Property<int>("PositiveResultCount");

                    b.Property<int>("ResultFileSizeAvg");

                    b.Property<int>("ResultFileSizeMax");

                    b.Property<int>("ResultFileSizeMin");

                    b.Property<long>("ResultFileSizeSum");

                    b.Property<int>("TotalCount");

                    b.Property<long>("TotalFileSizeSum");

                    b.HasKey("ConvertStatTotalId");

                    b.ToTable("vwConvertStatTotal");
                });

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.FileCategory", b =>
                {
                    b.Property<int>("FileCategoryId");

                    b.Property<string>("FileCategoryCode")
                        .IsRequired();

                    b.HasKey("FileCategoryId");

                    b.HasAlternateKey("FileCategoryCode");

                    b.HasIndex("FileCategoryCode")
                        .IsUnique();

                    b.HasIndex("FileCategoryId")
                        .IsUnique();

                    b.ToTable("tbFileCategories");
                });

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.FileType", b =>
                {
                    b.Property<int>("FileTypeId");

                    b.Property<int>("FileCategoryId");

                    b.Property<string>("FileExtension")
                        .IsRequired();

                    b.HasKey("FileTypeId");

                    b.HasAlternateKey("FileExtension");

                    b.HasIndex("FileCategoryId");

                    b.HasIndex("FileExtension")
                        .IsUnique();

                    b.HasIndex("FileTypeId")
                        .IsUnique();

                    b.ToTable("tbFileTypes");
                });

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.ConvertRequest", b =>
                {
                    b.HasOne("PrecizeSoft.GetPdfOnline.Model.FileType", "FileType")
                        .WithMany("ConvertRequests")
                        .HasForeignKey("FileTypeId");
                });

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.ConvertResponse", b =>
                {
                    b.HasOne("PrecizeSoft.GetPdfOnline.Model.ConvertRequest", "Request")
                        .WithOne("Response")
                        .HasForeignKey("PrecizeSoft.GetPdfOnline.Model.ConvertResponse", "ConvertResponseId");

                    b.HasOne("PrecizeSoft.GetPdfOnline.Model.ConvertResultType", "ResultType")
                        .WithMany("ConvertResponses")
                        .HasForeignKey("ResultTypeId");
                });

            modelBuilder.Entity("PrecizeSoft.GetPdfOnline.Model.FileType", b =>
                {
                    b.HasOne("PrecizeSoft.GetPdfOnline.Model.FileCategory", "FileCategory")
                        .WithMany("FileTypes")
                        .HasForeignKey("FileCategoryId");
                });
        }
    }
}
