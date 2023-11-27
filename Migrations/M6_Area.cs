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
            Delete.Table("Area").InSchema("videostore");
        }

        public override void Up()
        {
            Create.Table("Area")
                .InSchema("videostore")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("Name").AsString(255);
        }
    }
}
