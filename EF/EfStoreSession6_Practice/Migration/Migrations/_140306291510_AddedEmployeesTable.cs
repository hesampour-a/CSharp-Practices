using EfStoreSession6_Practice.Entities;
using FluentMigrator;

namespace Migrations.Migrations;
[Migration(140306291510)]
public class _140306291510_AddedEmployeesTable : Migration
{
    public override void Up()
    {
        Create.Table("Employees")
            .WithColumn(nameof(Employee.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn("UserId").AsInt32().NotNullable()
            .ForeignKey("FK_Employees_Users", "Users","Id")
            .WithColumn("StoreId").AsInt32().Nullable()
            .ForeignKey("FK_Employees_Stores", "Stores","Id")
            .WithColumn("PersonnelNumber").AsString(10).Nullable();

        // Create.ForeignKey("UserId").FromTable("Users").ForeignColumns("Id");
        // Create.ForeignKey("StoreId").FromTable("Stores").ForeignColumns("Id");
    }

    public override void Down()
    {
        Delete.Table("Employees");
    }
}