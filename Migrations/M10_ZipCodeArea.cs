using FluentMigrator;

namespace Migrations
{
    [Migration(10)]
    public class M10_ZipCodeArea : Migration
    {
        public override void Down()
        {
            Delete.UniqueConstraint("PK_ZipCodeToArea")
                .FromTable("ZipCodeToArea")
                .InSchema("videostore");

            Delete.ForeignKey("FK_ZipCodeToArea_Area")
                .OnTable("ZipCodeToArea")
                .InSchema("videostore");

            Delete.ForeignKey("FK_ZipCodeToArea_ZipCode")
                .OnTable("ZipCodeToArea")
                .InSchema("videostore");

            Delete.Table("ZipCodeToArea")
                .InSchema("videostore");
        }

        public override void Up()
        {
            Create.Table("ZipCodeToArea")
                .InSchema("videostore")
                .WithColumn("Area_Id").AsInt64().NotNullable()
                .WithColumn("ZipCode_Id").AsString(255).NotNullable();

            Create.ForeignKey("FK_ZipCodeToArea_Area")
                .FromTable("ZipCodeToArea")
                .InSchema("videostore")
                .ForeignColumn("Area_Id")
                .ToTable("Area")
                .InSchema("videostore")
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade)
                .OnUpdate(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_ZipCodeToArea_ZipCode")
                .FromTable("ZipCodeToArea")
                .InSchema("videostore")
                .ForeignColumn("ZipCode_Id")
                .ToTable("ZipCode")
                .InSchema("videostore")
                .PrimaryColumn("Code")
                .OnDelete(System.Data.Rule.Cascade)
                .OnUpdate(System.Data.Rule.Cascade);

            Create.UniqueConstraint("PK_ZipCodeToArea")
                .OnTable("ZipCodeToArea")
                .WithSchema("videostore")
                .Columns("Area_Id", "ZipCode_Id");
        }
    }
}
