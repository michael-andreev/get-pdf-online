using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Migrations
{
    public partial class vwConvertStatByHour : Migration
    {
        string UpScript = @"CREATE VIEW vwConvertStatByHour AS
SELECT strftime('%Y-%m-%d %H:00:00', RequestDateUtc) AS BeginRequestDateUtc,
       datetime(strftime('%Y-%m-%d %H:00:00', RequestDateUtc), '+1 hours') AS EndRequestDateUtc,
       0 AS UtcMinutesOffset,
       COUNT( * ) AS TotalCount,
       SUM(FileSize) AS FileSizeSum,
       SUM(ResultFileSize) AS ResultFileSizeSum,
       SUM(FileSize) + SUM(ResultFileSize) AS TotalFileSizeSum
  FROM vwConvertLogs
 GROUP BY strftime('%Y-%m-%d %H:00:00', RequestDateUtc) 
UNION ALL
SELECT strftime('%Y-%m-%d %H:15:00', RequestDateUtc, '-15 minutes') AS BeginRequestDateUtc,
       datetime(strftime('%Y-%m-%d %H:15:00', RequestDateUtc, '-15 minutes'), '+1 hours') AS EndRequestDateUtc,
       15 AS UtcMinutesOffset,
       COUNT( * ) AS TotalCount,
       SUM(FileSize) AS FileSizeSum,
       SUM(ResultFileSize) AS ResultFileSizeSum,
       SUM(FileSize) + SUM(ResultFileSize) AS TotalFileSizeSum
  FROM vwConvertLogs
 GROUP BY strftime('%Y-%m-%d %H:15:00', RequestDateUtc, '-15 minutes') 
UNION ALL
SELECT strftime('%Y-%m-%d %H:30:00', RequestDateUtc, '-30 minutes') AS BeginRequestDateUtc,
       datetime(strftime('%Y-%m-%d %H:30:00', RequestDateUtc, '-30 minutes'), '+1 hours') AS EndRequestDateUtc,
       30 AS UtcMinutesOffset,
       COUNT( * ) AS TotalCount,
       SUM(FileSize) AS FileSizeSum,
       SUM(ResultFileSize) AS ResultFileSizeSum,
       SUM(FileSize) + SUM(ResultFileSize) AS TotalFileSizeSum
  FROM vwConvertLogs
 GROUP BY strftime('%Y-%m-%d %H:30:00', RequestDateUtc, '-30 minutes') 
UNION ALL
SELECT strftime('%Y-%m-%d %H:45:00', RequestDateUtc, '-45 minutes') AS BeginRequestDateUtc,
       datetime(strftime('%Y-%m-%d %H:45:00', RequestDateUtc, '-45 minutes'), '+1 hours') AS EndRequestDateUtc,
       45 AS UtcMinutesOffset,
       COUNT( * ) AS TotalCount,
       SUM(FileSize) AS FileSizeSum,
       SUM(ResultFileSize) AS ResultFileSizeSum,
       SUM(FileSize) + SUM(ResultFileSize) AS TotalFileSizeSum
  FROM vwConvertLogs
 GROUP BY strftime('%Y-%m-%d %H:45:00', RequestDateUtc, '-45 minutes');";

        string DownScript = @"DROP VIEW vwConvertStatByHour;";

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
