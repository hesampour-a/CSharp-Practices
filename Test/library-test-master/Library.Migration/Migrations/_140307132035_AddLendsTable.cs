using FluentMigrator;

namespace Library.Migration.Migrations;
[Migration(140307132035)]
public class _140307132035_AddLendsTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Lends")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("LendDate").AsDate().NotNullable()
            .WithColumn("ReturnDate").AsDate().NotNullable()
            .WithColumn("BookId").AsInt32().NotNullable()
            .ForeignKey("FK_Books_Lends", "Books", "Id")
            .WithColumn("UserId").AsInt32().NotNullable()
            .ForeignKey("FK_Users_Lends", "Users", "Id");

    }

    public override void Down()
    {
        Delete.Table("Lends");
    }
}