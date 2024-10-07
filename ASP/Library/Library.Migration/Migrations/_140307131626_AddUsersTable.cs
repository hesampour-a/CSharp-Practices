using FluentMigrator;

namespace Library.Migration.Migrations;
[Migration(140307131626)]
public class _140307131626_AddUsersTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("JoinDate").AsDate().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Users");
    }
}