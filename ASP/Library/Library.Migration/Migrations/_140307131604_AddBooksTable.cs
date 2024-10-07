using FluentMigrator;

namespace Library.Migration.Migrations;
[Migration(140307131604)]
public class _140307131604_AddBooksTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Books")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Books");
    }
}