using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(4)]
    public class M4_ZipCode : Migration
    {
        public override void Down()
        {
            Delete.Table("ZipCodes").InSchema("videostore");
        }

        public override void Up()
        {
            Create.Table("ZipCodes")
                .InSchema("videostore")
                .WithColumn("Code").AsString(255).PrimaryKey()
                .WithColumn("City").AsString(255)
                .WithColumn("State").AsString(255);
        }
    }
}
