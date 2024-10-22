using FluentMigrator;

namespace Library.Migration.Migrations;
[Migration(140307191422)]
public class _140307191422_AddOrderItemsTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("OrderItems")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("OrderId").AsInt32().NotNullable()
            .ForeignKey("Fk_OrderItems_Orders", "Orders", "Id")
            .WithColumn("ProductId").AsInt32().NotNullable()
            .ForeignKey("Fk_OrderItems_Products", "Products", "Id");
    }

    public override void Down()
    {
        Delete.Table("OrderItems");
    }
}