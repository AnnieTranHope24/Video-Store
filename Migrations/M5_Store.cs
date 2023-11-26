
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(5)]
    public class M5_Store : Migration
    {
        public override void Down()
        {
            Delete.Table("Stores").InSchema("videostore");
        }

        public override void Up()
        {

        Create.Table("Stores")
                .InSchema("videostore")
                .WithColumn("ID").AsInt64().Identity().PrimaryKey()
                .WithColumn("StreetAddress").AsString(255).NotNullable()
                .WithColumn("ZipCodeID").AsString(255).ForeignKey("ZipCodes", "Code")
                .WithColumn("PhoneNumber").AsString(255);
        }
    }
}