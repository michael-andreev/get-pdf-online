using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbConvertResultTypes",
                columns: table => new
                {
                    ConvertResultTypeId = table.Column<int>(nullable: false),
                    ConvertResultTypeCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbConvertResultTypes", x => x.ConvertResultTypeId);
                    table.UniqueConstraint("AK_tbConvertResultTypes_ConvertResultTypeCode", x => x.ConvertResultTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "tbFileCategories",
                columns: table => new
                {
                    FileCategoryId = table.Column<int>(nullable: false),
                    FileCategoryCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFileCategories", x => x.FileCategoryId);
                    table.UniqueConstraint("AK_tbFileCategories_FileCategoryCode", x => x.FileCategoryCode);
                });

            migrationBuilder.CreateTable(
                name: "tbFileTypes",
                columns: table => new
                {
                    FileTypeId = table.Column<int>(nullable: false),
                    FileCategoryId = table.Column<int>(nullable: false),
                    FileExtension = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFileTypes", x => x.FileTypeId);
                    table.UniqueConstraint("AK_tbFileTypes_FileExtension", x => x.FileExtension);
                    table.ForeignKey(
                        name: "FK_tbFileTypes_tbFileCategories_FileCategoryId",
                        column: x => x.FileCategoryId,
                        principalTable: "tbFileCategories",
                        principalColumn: "FileCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbConvertRequests",
                columns: table => new
                {
                    ConvertRequestId = table.Column<Guid>(nullable: false),
                    FileExtension = table.Column<string>(nullable: true),
                    FileSize = table.Column<int>(nullable: false),
                    FileTypeId = table.Column<int>(nullable: false),
                    RequestDateUtc = table.Column<DateTime>(type: "REAL", nullable: false),
                    SenderIp = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbConvertRequests", x => x.ConvertRequestId);
                    table.ForeignKey(
                        name: "FK_tbConvertRequests_tbFileTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "tbFileTypes",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbConvertResponses",
                columns: table => new
                {
                    ConvertResponseId = table.Column<Guid>(nullable: false),
                    ResponseDateUtc = table.Column<DateTime>(type: "REAL", nullable: false),
                    ResultFileSize = table.Column<int>(nullable: true),
                    ResultTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbConvertResponses", x => x.ConvertResponseId);
                    table.ForeignKey(
                        name: "FK_tbConvertResponses_tbConvertRequests_ConvertResponseId",
                        column: x => x.ConvertResponseId,
                        principalTable: "tbConvertRequests",
                        principalColumn: "ConvertRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbConvertResponses_tbConvertResultTypes_ResultTypeId",
                        column: x => x.ResultTypeId,
                        principalTable: "tbConvertResultTypes",
                        principalColumn: "ConvertResultTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbConvertRequests_ConvertRequestId",
                table: "tbConvertRequests",
                column: "ConvertRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbConvertRequests_FileExtension",
                table: "tbConvertRequests",
                column: "FileExtension");

            migrationBuilder.CreateIndex(
                name: "IX_tbConvertRequests_FileTypeId",
                table: "tbConvertRequests",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbConvertRequests_RequestDateUtc",
                table: "tbConvertRequests",
                column: "RequestDateUtc");

            migrationBuilder.CreateIndex(
                name: "IX_tbConvertRequests_SenderIp",
                table: "tbConvertRequests",
                column: "SenderIp");

            migrationBuilder.CreateIndex(
                name: "IX_tbConvertResponses_ConvertResponseId",
                table: "tbConvertResponses",
                column: "ConvertResponseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbConvertResponses_ResponseDateUtc",
                table: "tbConvertResponses",
                column: "ResponseDateUtc");

            migrationBuilder.CreateIndex(
                name: "IX_tbConvertResponses_ResultTypeId",
                table: "tbConvertResponses",
                column: "ResultTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbConvertResultTypes_ConvertResultTypeCode",
                table: "tbConvertResultTypes",
                column: "ConvertResultTypeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbConvertResultTypes_ConvertResultTypeId",
                table: "tbConvertResultTypes",
                column: "ConvertResultTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbFileCategories_FileCategoryCode",
                table: "tbFileCategories",
                column: "FileCategoryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbFileCategories_FileCategoryId",
                table: "tbFileCategories",
                column: "FileCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbFileTypes_FileCategoryId",
                table: "tbFileTypes",
                column: "FileCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbFileTypes_FileExtension",
                table: "tbFileTypes",
                column: "FileExtension",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbFileTypes_FileTypeId",
                table: "tbFileTypes",
                column: "FileTypeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbConvertResponses");

            migrationBuilder.DropTable(
                name: "tbConvertRequests");

            migrationBuilder.DropTable(
                name: "tbConvertResultTypes");

            migrationBuilder.DropTable(
                name: "tbFileTypes");

            migrationBuilder.DropTable(
                name: "tbFileCategories");
        }
    }
}
