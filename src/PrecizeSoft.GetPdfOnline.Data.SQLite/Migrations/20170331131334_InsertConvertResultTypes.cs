using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Migrations
{
    public partial class InsertConvertResultTypes : Migration
    {
        string UpScript = @"INSERT INTO tbConvertResultTypes (
                                     ConvertResultTypeCode,
                                     ConvertResultTypeId
                                 )
                                 VALUES (
                                     'UNKNOWN',
                                     0
                                 ),
                                 (
                                     'Positive',
                                     1
                                 ),
                                 (
                                     'FileBytesEmpty',
                                     10
                                 ),
                                 (
                                     'FileExtensionEmpty',
                                     20
                                 ),
                                 (
                                     'InvalidFileExtension',
                                     30
                                 ),
                                 (
                                     'FormatNotSupported',
                                     40
                                 ),
                                 (
                                     'OtherError',
                                     99
                                 );";

        string DownScript = @"DELETE FROM tbConvertResultTypes
      WHERE ConvertResultTypeId IN (0, 10, 20, 30, 40, 99);";

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
