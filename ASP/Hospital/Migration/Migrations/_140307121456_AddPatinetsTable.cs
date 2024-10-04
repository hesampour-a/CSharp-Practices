using FluentMigrator;

namespace Migration.Migrations;
[Migration(140307121456)]
public class _140307121456_AddPatinetsTable : FluentMigrator.Migration
{
    public override void Up()
    {
       Create.Table("Patinets")
           .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
           .WithColumn("Name").AsString().NotNullable()
           .WithColumn("DoctorId").AsInt32().NotNullable().ForeignKey("Fk_Patients_Doctor", "Doctors","Id");
    }

    public override void Down()
    {
       Delete.Table("Patinets");
    }
}