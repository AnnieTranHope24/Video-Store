using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    [Migration(11)]
    public class M11_CustomerStore : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("CustomerStore")
                .OnTable("Customer")
                .InSchema("videostore");

            Delete.Column("Store_Id")
                .FromTable("Customer")
                .InSchema("videostore");
        }

        public override void Up()
        {
            Create.Column("Store_Id")
                .OnTable("Customer")
                .InSchema("videostore")
                .AsInt64()
                .NotNullable();

            Create.ForeignKey("CustomerToStore")
                .FromTable("Customer")
                .InSchema("videostore")
                .ForeignColumn("Store_Id")
                .ToTable("Store")
                .InSchema("videostore")
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade)
                .OnUpdate(System.Data.Rule.Cascade);
        }
    }
}
