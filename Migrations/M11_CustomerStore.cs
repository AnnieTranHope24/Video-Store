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

            // Code to create an entirely different table.
            // Delete.Table("CustomerStore")
            //    .InSchema("videostore");

            Delete.ForeignKey("CustomerStore")
                .OnTable("Customer")
                .InSchema("videostore");

            Delete.Column("Store_Id")
                .FromTable("Customer")
                .InSchema("videostore");
        }

        public override void Up()
        {
            // If we need to create a table
            //Create.Table("CustomerStore")
            //    .InSchema("videostore")
            //    .WithColumn("Customer_Id").AsInt64().NotNullable()
            //    .WithColumn("Store_Id").AsInt64().NotNullable();

            //Create.ForeignKey("FK_CustomerStore_Customer")
            //    .FromTable("CustomerStore").ForeignColumn("Customer_Id")
            //    .ToTable("Customer").InSchema("videostore").PrimaryColumn("Id");

            //Create.ForeignKey("FK_AreaZipCode_Store")
            //    .FromTable("CustomerStore").ForeignColumn("Store_Id")
            //    .ToTable("Store").InSchema("videostore").PrimaryColumn("Id");

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
