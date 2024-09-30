using FluentMigrator;

namespace Migrations.Migrations;
[Migration(140306291505)]
public class _140306291505_AddedStoresTable : Migration
{
    public override void Up()
    {
        Create.Table("Stores")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(100).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Stores");
    }
}