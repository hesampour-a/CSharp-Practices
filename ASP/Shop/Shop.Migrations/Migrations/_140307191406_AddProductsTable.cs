using FluentMigrator;

namespace Library.Migration.Migrations;
[Migration(140307191406)]
public class _140307191406_AddProductsTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Products")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString().NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable()
            .WithColumn("AvailableCount").AsInt32().NotNullable();
    }

    public override void Down()
    {
       Delete.Table("Products");
    }
}