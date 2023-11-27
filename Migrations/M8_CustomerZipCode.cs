using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(8)]
    public class M8_CustomerZipCode : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("CustomerToZipCode")
                .OnTable("Customer")
                .InSchema("videostore");

            Delete.Column("ZipCode_Id")
                .FromTable("Customer")
                .InSchema("videostore");
        }

        public override void Up()
        {
            Create.Column("ZipCode_Id")
                .OnTable("Customer")
                .InSchema("videostore")
                .AsString(255)
                .Nullable();

            Create.ForeignKey("CustomerToZipCode")
                .FromTable("Customer")
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
