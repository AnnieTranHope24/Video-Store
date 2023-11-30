using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(10)]
    public class M10_ZipCodeArea : Migration
    {
        public override void Down()
        {
            // Code to create an entirely different table.
            // Delete.Table("AreaZipCode")
            //    .InSchema("videostore");

            Delete.ForeignKey("ZipCodeToArea")
                .OnTable("Area")
                .InSchema("videostore");

            Delete.Column("ZipCode_Id")
                .FromTable("Area")
                .InSchema("videostore");
        }

        public override void Up()
        {
            // If we need to create a table
            //Create.Table("AreaZipCode")
            //    .InSchema("videostore")
            //    .WithColumn("Area_Id").AsInt64().NotNullable()
            //    .WithColumn("ZipCode_Id").AsString(255).NotNullable();

            //Create.ForeignKey("FK_AreaZipCode_Area")
            //    .FromTable("AreaZipCode").ForeignColumn("ZipCode_Id")
            //    .ToTable("Area").InSchema("videostore").PrimaryColumn("Id");

            //Create.ForeignKey("FK_AreaZipCode_ZipCode")
            //    .FromTable("AreaZipCode").ForeignColumn("Area_Id")
            //    .ToTable("ZipCode").InSchema("videostore").PrimaryColumn("Code");


            Create.Column("ZipCode_Id")
                .OnTable("Area")
                .InSchema("videostore")
                .AsString(255)
                .Nullable();

            Create.ForeignKey("ZipCodeToArea")
                .FromTable("Area")
                .InSchema("videostore")
                .ForeignColumn("ZipCode_Id")
                .ToTable("ZipCode")
                .InSchema("videostore")
                .PrimaryColumn("Code")
                .OnDelete(System.Data.Rule.SetNull)
                .OnUpdate(System.Data.Rule.Cascade);
        }
    }
}
