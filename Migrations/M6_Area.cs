using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(6)]
    public class M6_Area : Migration
    {
        public override void Down()
        {
            Delete.Table("AreaZipCodes").InSchema("videostore");
            Delete.Table("Areas").InSchema("videostore");
        }

        public override void Up()
        {
            Create.Table("Areas")
                .InSchema("videostore")
                .WithColumn("ID").AsInt64().Identity().PrimaryKey()
                .WithColumn("Name").AsString(255);

            Create.Table("AreaZipCodes")
                .InSchema("videostore")
                .WithColumn("AreaID").AsInt64().ForeignKey("Areas", "ID")
                .WithColumn("ZipCodeID").AsString(255).ForeignKey("ZipCodes", "Code");

            Create.UniqueConstraint("UC_AreaZipCodes")
                .OnTable("AreaZipCodes")
                .Columns("AreaID", "ZipCodeID");
        }
    }
}
