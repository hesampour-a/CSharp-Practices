using FluentMigrator;

namespace Library.Migration.Migrations;
[Migration(140307161166)]
public class _140307161166_AddRatesTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Rates")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("BookId").AsInt32().NotNullable().ForeignKey("Fk_Rates_Bookd", "Books", "Id")
            .WithColumn("Score").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Rates");
    }
}