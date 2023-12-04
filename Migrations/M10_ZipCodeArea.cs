using FluentMigrator;

namespace Migrations
{
    [Migration(10)]
    public class M10_ZipCodeArea : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("FK_AreaZipCode_Area")
                .OnTable("AreaZipCode")
                .InSchema("videostore");

            Delete.ForeignKey("FK_AreaZipCode_ZipCode")
                .OnTable("AreaZipCode")
                .InSchema("videostore");

            Delete.Table("AreaZipCode")
               .InSchema("videostore");
        }

        public override void Up()
        {
            Create.Table("AreaZipCode")
                .InSchema("videostore")
                .WithColumn("Area_Id").AsInt64().NotNullable().PrimaryKey()
                .WithColumn("ZipCode_Id").AsString(255).NotNullable().PrimaryKey();

            Create.ForeignKey("FK_AreaZipCode_Area")
                .FromTable("AreaZipCode")
                .InSchema("videostore")
                .ForeignColumn("Area_Id")
                .ToTable("Area")
                .InSchema("videostore")
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade)
                .OnUpdate(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_AreaZipCode_ZipCode")
                .FromTable("AreaZipCode")
                .InSchema("videostore")
                .ForeignColumn("ZipCode_Id")
                .ToTable("ZipCode")
                .InSchema("videostore")
                .PrimaryColumn("Code")
                .OnDelete(System.Data.Rule.Cascade)
                .OnUpdate(System.Data.Rule.Cascade);
        }
    }
}
