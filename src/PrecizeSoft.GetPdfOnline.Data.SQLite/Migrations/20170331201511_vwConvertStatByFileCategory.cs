using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Migrations
{
    public partial class vwConvertStatByFileCategory : Migration
    {
        string UpScript = @"CREATE VIEW vwConvertStatByFileCategory AS
    SELECT FileCategoryId,
       FileCategoryCode,
       COUNT( * ) AS TotalCount,
       SUM(FileSize) AS FileSizeSum,
       AVG(FileSize) AS FileSizeAvg,
       MIN(FileSize) AS FileSizeMin,
       MAX(FileSize) AS FileSizeMax
  FROM vwConvertLogs
 GROUP BY FileCategoryId, FileCategoryCode;";

        string DownScript = @"DROP VIEW vwConvertStatByFileCategory;";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(UpScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(DownScript);
        }
    }
}
