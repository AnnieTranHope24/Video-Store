using FluentMigrator;

namespace Migrations
{
    [Migration(11)]
    public class M11_StoreToCustomer : Migration
    {
        public override void Down()
        {
            Delete.UniqueConstraint("PK_StoreToCustomer")
                .FromTable("StoreToCustomer")
                .InSchema("videostore");

            Delete.ForeignKey("FK_StoreToCustomer_Customer")
                .OnTable("StoreToCustomer")
                .InSchema("videostore");

            Delete.ForeignKey("FK_StoreToCustomer_Store")
                .OnTable("StoreToCustomer")
                .InSchema("videostore");

            Delete.Table("StoreToCustomer")
                .InSchema("videostore");
        }

        public override void Up()
        {
            Create.Table("StoreToCustomer")
                .InSchema("videostore")
                .WithColumn("Customer_Id").AsInt64().NotNullable()
                .WithColumn("Store_Id").AsInt64().NotNullable()
                .WithColumn("StoreOrder").AsInt64().Nullable();

            Create.ForeignKey("FK_StoreToCustomer_Customer")
                .FromTable("StoreToCustomer")
                .InSchema("videostore")
                .ForeignColumn("Customer_Id")
                .ToTable("Customer")
                .InSchema("videostore")
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade)
                .OnUpdate(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_StoreToCustomer_Store")
                .FromTable("StoreToCustomer")
                .InSchema("videostore")
                .ForeignColumn("Store_Id")
                .ToTable("Store")
                .InSchema("videostore")
                .PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.None)
                .OnUpdate(System.Data.Rule.None);

            Create.UniqueConstraint("PK_StoreToCustomer")
                .OnTable("StoreToCustomer")
                .WithSchema("videostore")
                .Columns("Customer_Id", "Store_Id");
        }
    }
}
