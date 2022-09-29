using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenFin.Core.Infra.Migrations
{
    public partial class GenFinDbv1 : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IdCategory = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    Name = table.Column<string>( type: "varchar(30)", maxLength: 30, nullable: false ),
                    ShowInCalendar = table.Column<bool>( type: "bit", nullable: false ),
                    RegistrationColumn = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    LastUpdateDate = table.Column<DateTime>( type: "datetime2", nullable: true ),
                    DeactivationDate = table.Column<DateTime>( type: "datetime2", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Category", x => x.IdCategory );
                } );

            migrationBuilder.CreateTable(
                name: "CostCenter",
                columns: table => new
                {
                    IdCostCenter = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    Name = table.Column<string>( type: "varchar(30)", maxLength: 30, nullable: false ),
                    RegistrationColumn = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    LastUpdateDate = table.Column<DateTime>( type: "datetime2", nullable: true ),
                    DeactivationDate = table.Column<DateTime>( type: "datetime2", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_CostCenter", x => x.IdCostCenter );
                } );

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    IdPaymentSource = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    Name = table.Column<string>( type: "varchar(30)", maxLength: 30, nullable: false ),
                    RegistrationColumn = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    LastUpdateDate = table.Column<DateTime>( type: "datetime2", nullable: true ),
                    DeactivationDate = table.Column<DateTime>( type: "datetime2", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_PaymentMethod", x => x.IdPaymentSource );
                } );

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    IdPaymentSource = table.Column<int>( type: "int", nullable: false ),
                    BestDayToBuy = table.Column<byte>( type: "tinyint", nullable: false, defaultValue: ( byte ) 1 ),
                    DueDate = table.Column<byte>( type: "tinyint", nullable: false, defaultValue: ( byte ) 1 ),
                    CreditLimit = table.Column<decimal>( type: "money", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_CreditCard", x => x.IdPaymentSource );
                    table.ForeignKey(
                        name: "FK_CreditCard_PaymentMethod_IdPaymentSource",
                        column: x => x.IdPaymentSource,
                        principalTable: "PaymentMethod",
                        principalColumn: "IdPaymentSource" );
                } );

            migrationBuilder.CreateTable(
                name: "PaymentSource",
                columns: table => new
                {
                    IdPaymentSource = table.Column<int>( type: "int", nullable: false ),
                    IncludeInBalance = table.Column<bool>( type: "bit", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_PaymentSource", x => x.IdPaymentSource );
                    table.ForeignKey(
                        name: "FK_PaymentSource_PaymentMethod_IdPaymentSource",
                        column: x => x.IdPaymentSource,
                        principalTable: "PaymentMethod",
                        principalColumn: "IdPaymentSource" );
                } );

            migrationBuilder.CreateTable(
                name: "RecurringTransaction",
                columns: table => new
                {
                    IdRecurringTransaction = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    IdPaymentMethod = table.Column<int>( type: "int", nullable: false ),
                    IdCostCenter = table.Column<int>( type: "int", nullable: false ),
                    IdCategory = table.Column<int>( type: "int", nullable: false ),
                    DateStart = table.Column<DateTime>( type: "date", nullable: false ),
                    Value = table.Column<decimal>( type: "money", nullable: false ),
                    Status = table.Column<byte>( type: "tinyint", nullable: false ),
                    Kind = table.Column<byte>( type: "tinyint", nullable: false ),
                    Description = table.Column<string>( type: "varchar(150)", maxLength: 150, nullable: false ),
                    Establishment = table.Column<string>( type: "varchar(50)", maxLength: 50, nullable: false ),
                    Frequency = table.Column<int>( type: "int", nullable: false ),
                    RegistrationColumn = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    LastUpdateDate = table.Column<DateTime>( type: "datetime2", nullable: true ),
                    DeactivationDate = table.Column<DateTime>( type: "datetime2", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_RecurringTransaction", x => x.IdRecurringTransaction );
                    table.ForeignKey(
                        name: "FK_RecurringTransaction_Category_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_RecurringTransaction_CostCenter_IdCostCenter",
                        column: x => x.IdCostCenter,
                        principalTable: "CostCenter",
                        principalColumn: "IdCostCenter",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_RecurringTransaction_PaymentMethod_IdPaymentMethod",
                        column: x => x.IdPaymentMethod,
                        principalTable: "PaymentMethod",
                        principalColumn: "IdPaymentSource",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    IdBill = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    IdCreditCard = table.Column<int>( type: "int", nullable: false ),
                    IdPaymentSource = table.Column<int>( type: "int", nullable: false ),
                    BillDueDate = table.Column<DateTime>( type: "date", nullable: false ),
                    PaidValue = table.Column<decimal>( type: "money", nullable: false ),
                    PaymentStatus = table.Column<byte>( type: "tinyint", nullable: false, defaultValue: ( byte ) 0 ),
                    RegistrationColumn = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    LastUpdateDate = table.Column<DateTime>( type: "datetime2", nullable: true ),
                    DeactivationDate = table.Column<DateTime>( type: "datetime2", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Bill", x => x.IdBill );
                    table.ForeignKey(
                        name: "FK_Bill_CreditCard_IdCreditCard",
                        column: x => x.IdCreditCard,
                        principalTable: "CreditCard",
                        principalColumn: "IdPaymentSource",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_Bill_PaymentSource_IdPaymentSource",
                        column: x => x.IdPaymentSource,
                        principalTable: "PaymentSource",
                        principalColumn: "IdPaymentSource",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    IdTransaction = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    IdPaymentSource = table.Column<int>( type: "int", nullable: false ),
                    IdCostCenter = table.Column<int>( type: "int", nullable: false ),
                    IdCategory = table.Column<int>( type: "int", nullable: false ),
                    Value = table.Column<decimal>( type: "money", nullable: false ),
                    PaymentStatus = table.Column<byte>( type: "tinyint", nullable: false ),
                    Kind = table.Column<byte>( type: "tinyint", nullable: false ),
                    Description = table.Column<string>( type: "varchar(150)", maxLength: 150, nullable: false ),
                    Establishment = table.Column<string>( type: "varchar(50)", maxLength: 50, nullable: false ),
                    Installment = table.Column<int>( type: "int", nullable: false ),
                    TotalInstallment = table.Column<int>( type: "int", nullable: false ),
                    RegistrationColumn = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    LastUpdateDate = table.Column<DateTime>( type: "datetime2", nullable: true ),
                    DeactivationDate = table.Column<DateTime>( type: "datetime2", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Transaction", x => x.IdTransaction );
                    table.ForeignKey(
                        name: "FK_Transaction_Category_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_Transaction_CostCenter_IdCostCenter",
                        column: x => x.IdCostCenter,
                        principalTable: "CostCenter",
                        principalColumn: "IdCostCenter",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_Transaction_PaymentSource_IdPaymentSource",
                        column: x => x.IdPaymentSource,
                        principalTable: "PaymentSource",
                        principalColumn: "IdPaymentSource",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "RecurringAdjust",
                columns: table => new
                {
                    IdRecurringAdjust = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    IdRecurringTransaction = table.Column<int>( type: "int", nullable: false ),
                    DateStart = table.Column<DateTime>( type: "date", nullable: false ),
                    Percent = table.Column<decimal>( type: "decimal (18,4)", nullable: false ),
                    RegistrationColumn = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    LastUpdateDate = table.Column<DateTime>( type: "datetime2", nullable: true ),
                    DeactivationDate = table.Column<DateTime>( type: "datetime2", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_RecurringAdjust", x => x.IdRecurringAdjust );
                    table.ForeignKey(
                        name: "FK_RecurringAdjust_RecurringTransaction_IdRecurringTransaction",
                        column: x => x.IdRecurringTransaction,
                        principalTable: "RecurringTransaction",
                        principalColumn: "IdRecurringTransaction",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateTable(
                name: "BillItem",
                columns: table => new
                {
                    IdBillItem = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    IdCostCenter = table.Column<int>( type: "int", nullable: false ),
                    IdCategory = table.Column<int>( type: "int", nullable: false ),
                    IdBill = table.Column<int>( type: "int", nullable: false ),
                    PurchaseDate = table.Column<DateTime>( type: "date", nullable: false ),
                    Value = table.Column<decimal>( type: "money", nullable: false ),
                    Description = table.Column<string>( type: "varchar(50)", maxLength: 50, nullable: false ),
                    Establishment = table.Column<string>( type: "varchar(50)", maxLength: 50, nullable: false ),
                    Installment = table.Column<int>( type: "int", nullable: false ),
                    TotalInstallment = table.Column<int>( type: "int", nullable: false ),
                    Kind = table.Column<byte>( type: "tinyint", nullable: false, defaultValue: ( byte ) 0 ),
                    RegistrationColumn = table.Column<DateTime>( type: "datetime2", nullable: false ),
                    LastUpdateDate = table.Column<DateTime>( type: "datetime2", nullable: true ),
                    DeactivationDate = table.Column<DateTime>( type: "datetime2", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_BillItem", x => x.IdBillItem );
                    table.ForeignKey(
                        name: "FK_BillItem_Bill_IdBill",
                        column: x => x.IdBill,
                        principalTable: "Bill",
                        principalColumn: "IdBill",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_BillItem_Category_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade );
                    table.ForeignKey(
                        name: "FK_BillItem_CostCenter_IdCostCenter",
                        column: x => x.IdCostCenter,
                        principalTable: "CostCenter",
                        principalColumn: "IdCostCenter",
                        onDelete: ReferentialAction.Cascade );
                } );

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdCreditCard",
                table: "Bill",
                column: "IdCreditCard" );

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdPaymentSource",
                table: "Bill",
                column: "IdPaymentSource" );

            migrationBuilder.CreateIndex(
                name: "IX_BillItem_IdBill",
                table: "BillItem",
                column: "IdBill" );

            migrationBuilder.CreateIndex(
                name: "IX_BillItem_IdCategory",
                table: "BillItem",
                column: "IdCategory" );

            migrationBuilder.CreateIndex(
                name: "IX_BillItem_IdCostCenter",
                table: "BillItem",
                column: "IdCostCenter" );

            migrationBuilder.CreateIndex(
                name: "IX_RecurringAdjust_IdRecurringTransaction",
                table: "RecurringAdjust",
                column: "IdRecurringTransaction" );

            migrationBuilder.CreateIndex(
                name: "IX_RecurringTransaction_IdCategory",
                table: "RecurringTransaction",
                column: "IdCategory" );

            migrationBuilder.CreateIndex(
                name: "IX_RecurringTransaction_IdCostCenter",
                table: "RecurringTransaction",
                column: "IdCostCenter" );

            migrationBuilder.CreateIndex(
                name: "IX_RecurringTransaction_IdPaymentMethod",
                table: "RecurringTransaction",
                column: "IdPaymentMethod" );

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_IdCategory",
                table: "Transaction",
                column: "IdCategory" );

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_IdCostCenter",
                table: "Transaction",
                column: "IdCostCenter" );

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_IdPaymentSource",
                table: "Transaction",
                column: "IdPaymentSource" );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "BillItem" );

            migrationBuilder.DropTable(
                name: "RecurringAdjust" );

            migrationBuilder.DropTable(
                name: "Transaction" );

            migrationBuilder.DropTable(
                name: "Bill" );

            migrationBuilder.DropTable(
                name: "RecurringTransaction" );

            migrationBuilder.DropTable(
                name: "CreditCard" );

            migrationBuilder.DropTable(
                name: "PaymentSource" );

            migrationBuilder.DropTable(
                name: "Category" );

            migrationBuilder.DropTable(
                name: "CostCenter" );

            migrationBuilder.DropTable(
                name: "PaymentMethod" );
        }
    }
}
