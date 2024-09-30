using System.Data;
using FluentMigrator;

namespace Migrations.Migrations;
[Migration(140306291614)]
public class _140306291614_AddedCustomersTable : Migration
{
    public override void Up()
    {
        Create.Table("Customers")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("UserId").AsInt32().NotNullable()
            //.ForeignKey("FK_Customers_Users", "Users", "Id").OnDelete(Rule.Cascade)
            .WithColumn("Address").AsString().NotNullable()
            .WithColumn("PostalCode").AsString().NotNullable();
        
        Create.ForeignKey("FK_Customers_Users")
            .FromTable("Customers")
            .ForeignColumn("UserId")
            .ToTable("Users")
            .PrimaryColumn("Id")
            .OnDelete(Rule.Cascade);
        
        
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_Customers_Users");
        Delete.Table("Customers");
    }
}