using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Migrations
{
    public partial class InsertFileCategories : Migration
    {
        string UpScript = @"INSERT INTO tbFileCategories (
                                 FileCategoryCode,
                                 FileCategoryId
                             )
                             VALUES (
                                 'UNKNOWN',
                                 0
                             ),
                             (
                                 'Document',
                                 10
                             ),
                             (
                                 'Spreadsheet',
                                 20
                             ),
                             (
                                 'Presentation',
                                 30
                             ),
                             (
                                 'Diagram',
                                 40
                             ),
                             (
                                 'Image',
                                 50
                             );";

        string DownScript = @"DELETE FROM tbFileCategories
      WHERE FileCategoryId IN (0, 10, 20, 30, 40, 50);";

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
