using FluentMigrator;

namespace Library.Migration.Migrations;
[Migration(140307131604)]
public class _140307131604_AddBooksTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Blocks")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("FloorCount").AsInt32().NotNullable()
            .WithColumn("CreationDate").AsDateTime().NotNullable();

        Create.Table("Floors")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("UnitCount").AsInt32().NotNullable()
            .WithColumn("BlockId").AsInt32().NotNullable()
            .ForeignKey("FK_Floors_Blocks", "Blocks", "Id");

        Create.Table("Units")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("FloorId").AsInt32().NotNullable()
            .WithColumn("IsActive").AsBoolean().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Floors");
        Delete.Table("Blocks");
        Delete.Table("Units");
    }
}