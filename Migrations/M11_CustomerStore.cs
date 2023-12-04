using FluentMigrator;

namespace Migrations
{
    [Migration(11)]
    public class M11_CustomerStore : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("FK_CustomerStore_Customer")
                .OnTable("CustomerStore")
                .InSchema("videostore");

            Delete.ForeignKey("FK_CustomerStore_Store")
                .OnTable("CustomerStore")
                .InSchema("videostore");

            Delete.Table("CustomerStore")
               .InSchema("videostore");
        }

        public override void Up()
        {
            Create.Table("CustomerStore")
                .InSchema("videostore")
                .WithColumn("Customer_Id").AsInt64().NotNullable().PrimaryKey()
                .WithColumn("Store_Id").AsInt64().NotNullable().PrimaryKey();

            Create.ForeignKey("FK_CustomerStore_Customer")
                .FromTable("CustomerStore")
                .InSchema("videostore")
                .ForeignColumn("Customer_Id")
                .ToTable("Customer")
                .InSchema("videostore")
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade)
                .OnUpdate(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_CustomerStore_Store")
                .FromTable("CustomerStore")
                .InSchema("videostore")
                .ForeignColumn("Store_Id")
                .ToTable("Store")
                .InSchema("videostore")
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.None)
                .OnUpdate(System.Data.Rule.None);
        }
    }
}
