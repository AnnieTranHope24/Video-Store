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
            Delete.ForeignKey("ZipCodeToArea")
                .OnTable("Area")
                .InSchema("videostore");

            Delete.Column("ZipCode_Id")
                .FromTable("Area")
                .InSchema("videostore");
        }

        public override void Up()
        {
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
