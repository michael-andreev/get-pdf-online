using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Migrations
{
    public partial class vwConvertStatByResultType : Migration
    {
        string UpScript = @"CREATE VIEW vwConvertStatByResultType AS
    SELECT ResultTypeId,
           ResultTypeCode,
           COUNT( * ) AS TotalCount
      FROM vwConvertLogs
     GROUP BY ResultTypeId,
              ResultTypeCode;";

        string DownScript = @"DROP VIEW vwConvertStatByResultType;";

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
