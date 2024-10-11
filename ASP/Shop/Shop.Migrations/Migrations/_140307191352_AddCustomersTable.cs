using FluentMigrator;

namespace Library.Migration.Migrations;
[Migration(140307191352)]
public class _140307191352_AddCustomersTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Customers")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("PhoneNumber").AsString().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Customers");
    }
}