using FluentMigrator;

namespace Migrations.Migrations;
[Migration(140306291449)]
public class _140306291449_AddedUsersTable : Migration
{
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("FirstName").AsString(100).NotNullable()
            .WithColumn("LastName").AsString(100).NotNullable()
            .WithColumn("PhoneNumber").AsString(10).NotNullable();
        //.WithColumn("MamadId").AsInt32().ForeignKey("Mamad", "Id");
    }

    public override void Down()
    {
        Delete.Table("Users");
    }
}