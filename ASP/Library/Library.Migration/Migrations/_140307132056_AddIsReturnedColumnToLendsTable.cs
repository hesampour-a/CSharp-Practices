using FluentMigrator;

namespace Library.Migration.Migrations;
[Migration(140307132056)]
public class _140307132056_AddIsREturndColumnToLendsTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Alter.Table("Lends")
            .AddColumn("IsReturned").AsBoolean().NotNullable();
    }

    public override void Down()
    {
        Delete.Column("IsReturned").FromTable("Lends");
    }
}