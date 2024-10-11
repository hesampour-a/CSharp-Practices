using FluentMigrator;

namespace Library.Migration.Migrations;
[Migration(140307191413)]
public class _140307191413_AddOrdersTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Orders")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("CustomerId").AsInt32().NotNullable()
            .ForeignKey("Fk_Orders_Customer", "Customers", "Id");
    }

    public override void Down()
    {
        Delete.Table("Orders");
    }
}