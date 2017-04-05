using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Migrations
{
    public partial class AddCustomAttributes : Migration
    {
        string UpScript = @"DROP VIEW vwConvertLogs;
CREATE VIEW vwConvertLogs AS
    SELECT tbConvertRequests.ConvertRequestId,
           tbConvertRequests.RequestDateUtc,
           tbConvertResponses.ResponseDateUtc,
           CAST ( (JulianDay(tbConvertResponses.ResponseDateUtc) - JulianDay(tbConvertRequests.RequestDateUtc) ) * 24 * 60 * 60 AS REAL) AS DurationInSeconds,
           tbConvertRequests.SenderIp,
           tbConvertRequests.FileExtension,
           tbConvertRequests.FileTypeId,
           tbFileCategories.FileCategoryId,
           tbFileCategories.FileCategoryCode,
           tbConvertRequests.FileSize,
           tbConvertRequests.CustomAttributes,
           IFNULL(tbConvertResponses.ResultTypeId, 0) AS ResultTypeId,
           IFNULL(tbConvertResultTypes.ConvertResultTypeCode, (SELECT ConvertResultTypeCode FROM tbConvertResultTypes WHERE ConvertResultTypeId = 0)) AS ResultTypeCode,
           tbConvertResponses.ResultFileSize
      FROM tbConvertRequests
           LEFT OUTER JOIN
           tbFileTypes ON tbConvertRequests.FileTypeId = tbFileTypes.FileTypeId
           LEFT OUTER JOIN
           tbFileCategories ON tbFileTypes.FileCategoryId = tbFileCategories.FileCategoryId
           LEFT OUTER JOIN
           tbConvertResponses ON tbConvertRequests.ConvertRequestId = tbConvertResponses.ConvertResponseId
           LEFT OUTER JOIN
           tbConvertResultTypes ON tbConvertResponses.ResultTypeId = tbConvertResultTypes.ConvertResultTypeId;";

        string DownScript = @"DROP VIEW vwConvertLogs;
CREATE VIEW vwConvertLogs AS
    SELECT tbConvertRequests.ConvertRequestId,
           tbConvertRequests.RequestDateUtc,
           tbConvertResponses.ResponseDateUtc,
           CAST ( (JulianDay(tbConvertResponses.ResponseDateUtc) - JulianDay(tbConvertRequests.RequestDateUtc) ) * 24 * 60 * 60 AS REAL) AS DurationInSeconds,
           tbConvertRequests.SenderIp,
           tbConvertRequests.FileExtension,
           tbConvertRequests.FileTypeId,
           tbFileCategories.FileCategoryId,
           tbFileCategories.FileCategoryCode,
           tbConvertRequests.FileSize,
           IFNULL(tbConvertResponses.ResultTypeId, 0) AS ResultTypeId,
           IFNULL(tbConvertResultTypes.ConvertResultTypeCode, (SELECT ConvertResultTypeCode FROM tbConvertResultTypes WHERE ConvertResultTypeId = 0)) AS ResultTypeCode,
           tbConvertResponses.ResultFileSize
      FROM tbConvertRequests
           LEFT OUTER JOIN
           tbFileTypes ON tbConvertRequests.FileTypeId = tbFileTypes.FileTypeId
           LEFT OUTER JOIN
           tbFileCategories ON tbFileTypes.FileCategoryId = tbFileCategories.FileCategoryId
           LEFT OUTER JOIN
           tbConvertResponses ON tbConvertRequests.ConvertRequestId = tbConvertResponses.ConvertResponseId
           LEFT OUTER JOIN
           tbConvertResultTypes ON tbConvertResponses.ResultTypeId = tbConvertResultTypes.ConvertResultTypeId;";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomAttributes",
                table: "tbConvertRequests",
                nullable: true);

            migrationBuilder.Sql(UpScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomAttributes",
                table: "tbConvertRequests");

            migrationBuilder.Sql(DownScript);
        }
    }
}
