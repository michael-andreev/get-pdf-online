using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Migrations
{
    public partial class vwConvertStatTotal : Migration
    {
        string UpScript = @"CREATE VIEW vwConvertStatTotal AS
SELECT 0 AS ConvertStatTotalId,
       MIN(RequestDateUtc) AS FirstRequestDateUtc,
       MAX(RequestDateUtc) AS LastRequestDateUtc,
       IFNULL(AVG(DurationInSeconds), 0) AS DurationInSecondsAvg,
       IFNULL(Min(DurationInSeconds), 0) AS DurationInSecondsMin,
       IFNULL(Max(DurationInSeconds), 0) AS DurationInSecondsMax,
       COUNT( * ) AS TotalCount,
       IFNULL( (
                   SELECT TotalCount
                     FROM vwConvertStatByResultType
                    WHERE ResultTypeId = 1
               ), 0) AS PositiveResultCount,
       COUNT( * ) - IFNULL( (
                                SELECT TotalCount
                                  FROM vwConvertStatByResultType
                                 WHERE ResultTypeId = 1
                            ), 0) AS NegativeResultCount,
       IFNULL(SUM(FileSize), 0) AS FileSizeSum,
       IFNULL(AVG(FileSize), 0) AS FileSizeAvg,
       IFNULL(MIN(FileSize), 0) AS FileSizeMin,
       IFNULL(MAX(FileSize), 0) AS FileSizeMax,
       IFNULL(SUM(ResultFileSize), 0) AS ResultFileSizeSum,
       IFNULL(AVG(ResultFileSize), 0) AS ResultFileSizeAvg,
       IFNULL(MIN(ResultFileSize), 0) AS ResultFileSizeMin,
       IFNULL(MAX(ResultFileSize), 0) AS ResultFileSizeMax,
       IFNULL(SUM(FileSize) + SUM(ResultFileSize), 0) AS TotalFileSizeSum
  FROM vwConvertLogs;";

        string DownScript = @"DROP VIEW vwConvertStatTotal;";

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
