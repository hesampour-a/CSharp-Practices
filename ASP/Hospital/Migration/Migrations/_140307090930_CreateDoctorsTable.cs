using FluentMigrator;
using Hospital.Api.Entities.Doctors;

namespace Migration.Migrations;
[Migration(140307090930)]
public class _140307090930_CreateDoctorsTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Doctors")
            .WithColumn(nameof(Doctor.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(Doctor.Name)).AsString().NotNullable()
            .WithColumn(nameof(Doctor.Specialty)).AsString().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Doctors");
    }
}